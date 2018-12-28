using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripTime.API.Users.DTO;
using TripTime.API.Users.DTO.UserDTO;
using TripTime.API.Users.Mapper;
using TripTime.Domain.Users;
using TripTime.Service.Users;
using TripTime.Service.Users.Security;

namespace TripTime.API.Users.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserAuthenticationService _userAuthenticationService;
        private readonly UserMapper _userMapper;


        public LoginController(IUserService userService, UserAuthenticationService userAuthenticationService, UserMapper userMapper)
        {
            _userService = userService;
            _userAuthenticationService = userAuthenticationService;
            _userMapper = userMapper;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public ActionResult<TokenDTO> Authenticate([FromBody] LoginDTO userRequestDto)
        {
            var securityToken = _userAuthenticationService.Authenticate(userRequestDto.Email, userRequestDto.Password);

            if (securityToken != null)
            {
                TokenDTO token = new TokenDTO();
                token.Token = securityToken.RawData;
                return Ok(token);
            }

            return BadRequest("Email or Password incorrect!");
        }

        [HttpGet("current")]
        [Authorize]
        public ActionResult<UserDTO_Return> GeCurrentUser()
        {
            var authenticatedUser = _userAuthenticationService.GetCurrentLoggedInUser(User);
            if (authenticatedUser != null)
            {
                return Ok(_userMapper.DomainToDto(authenticatedUser));
            }
            return BadRequest("Could not find your user information... Contact us :)");
        }
    }
}
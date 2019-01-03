using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<TokenDTO>> Authenticate([FromBody] LoginDTO userRequestDto)
        {
            var securityToken = await _userAuthenticationService.Authenticate(userRequestDto.Email, userRequestDto.Password);

            TokenDTO token = new TokenDTO();
            token.Token = securityToken.RawData;
            return Ok(token);
        }

        [HttpGet("current")]
        [Authorize]
        public async Task<ActionResult<UserDTO_Return>> GeCurrentUser()
        {
            var authenticatedUser = await _userAuthenticationService.GetCurrentLoggedInUser(User);
            return Ok(_userMapper.DomainToDto(authenticatedUser));
        }
    }
}
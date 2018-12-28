using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.Users.DTO.AdminDTO;
using TripTime.API.Users.Mapper;
using TripTime.Domain.Users;
using TripTime.Service.Users;
using TripTime.Service.Users.Security;

namespace TripTime.API.Users.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly AdminMapper _adminMapper;
        private readonly IUserService _userService;

        public AdminsController(AdminMapper clientMapper, IUserService userService)
        {
            _adminMapper = clientMapper;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<AdminDTO_Return>> Register([FromBody] AdminDTO_Create givenClientDTO)
        {
            var user = _adminMapper.DtoToDomain(givenClientDTO);
            var userId = await _userService.CreateNew(user);
            var createdUser = await _userService.GetAdminById(userId);
            if (createdUser == null)
            {
                return BadRequest();
            }
            AdminDTO_Return userDto = _adminMapper.DomainToDto(createdUser);
            return Ok(userDto);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AdminDTO_Return>> GetById(string id)
        {
            var foundUser = await _userService.GetAdminById(id);
            if (foundUser != null)
            {
                return Ok(_adminMapper.DomainToDto(foundUser));
            }
            return BadRequest("Could not find your user information...");
        }

    }
}
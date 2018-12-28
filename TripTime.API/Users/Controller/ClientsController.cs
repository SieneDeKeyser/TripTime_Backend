using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripTime.API.Users.DTO;
using TripTime.API.Users.DTO.ClientDTO;
using TripTime.API.Users.Mapper;
using TripTime.Domain.Users;
using TripTime.Service.Users;
using TripTime.Service.Users.Security;

namespace TripTime.API.Users.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientMapper _clientMapper;
        private readonly IUserService _userService;

        public ClientsController(ClientMapper clientMapper, IUserService userService)
        {
            _clientMapper = clientMapper;
            _userService = userService;            
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ClientDTO_Return>> Register([FromBody] ClientDTO_Create givenClientDTO)
        {
            var user = _clientMapper.DtoToDomain(givenClientDTO);
            var userId = await _userService.CreateNew(user);
            var createdUser = await _userService.GetClientById(userId);
            if (createdUser == null)
            {
                return BadRequest();
            }
            ClientDTO_Return userDto = _clientMapper.DomainToDto(createdUser);
            return Ok(userDto);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ClientDTO_Return>> GetById(string id)
        {
            var foundUser = await _userService.GetClientById(id);
            if (foundUser != null)
            {
                return Ok(_clientMapper.DomainToDto(foundUser));
            }
            return BadRequest("Could not find your user information...");
        }
    }
}

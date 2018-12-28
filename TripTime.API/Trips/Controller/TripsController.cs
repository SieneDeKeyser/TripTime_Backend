using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripTime.API.Trips.DTO;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.Trips;

namespace TripTime.API.Trips.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IMapper<Trip, TripDTO_Create, TripDTO_Return> _tripMapper;
        private readonly ITripService _tripService;

        public TripsController(IMapper<Trip, TripDTO_Create, TripDTO_Return> mapper, ITripService service)
        {
            _tripMapper = mapper;
            _tripService = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TripDTO_Return>> CreateNewTrip([FromBody] TripDTO_Create givenTripDTO)
        {
            var trip = _tripMapper.DtoToDomain(givenTripDTO);
            var tripId = await _tripService.Create(trip);
            TripDTO_Return tripDto = _tripMapper.DomainToDto(await _tripService.GetTripById(Guid.Parse(tripId)));
            return Created($"api/Trips/{tripId}", tripId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripTime.API.Trips.DTO.Hotels;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.Trips.Hotels;

namespace TripTime.API.Trips.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMapper<Hotel, HotelDTO_Create, HotelDTO_Return> _hotelMapper;
        private readonly IHotelService _hotelService;

        public HotelsController(IMapper<Hotel, HotelDTO_Create, HotelDTO_Return> hotelMapper, IHotelService hotelService)
        {
            _hotelMapper = hotelMapper;
            _hotelService = hotelService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<HotelDTO_Return>> CreateNewHotel([FromBody] HotelDTO_Create givenHotelDTO)
        {
            var hotel = _hotelMapper.DtoToDomain(givenHotelDTO);
            var hotelId = await _hotelService.Create(hotel);
            HotelDTO_Return hotelDto = _hotelMapper.DomainToDto(await _hotelService.GetHotelById(Guid.Parse(hotelId)));
            return Created($"api/Hotels/{hotelId}", hotelId);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<HotelDTO_Return>>> GetAllHotels()
        {
            var allHotelsDto = _hotelMapper.DomainListToDtoList( await _hotelService.GetAllHotels());
            return Ok(allHotelsDto);
        }

        [HttpGet ("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<HotelDTO_Return>> GetById(string id)
        {
            return Ok(_hotelMapper.DomainToDto(await _hotelService.GetHotelById(Guid.Parse(id))));
        }
    }
}
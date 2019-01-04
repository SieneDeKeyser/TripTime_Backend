using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;
using TripTime.API.Trips.Controller;
using TripTime.API.Trips.DTO.Hotels;
using TripTime.Domain.ContactInformation;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.Trips.Hotels;
using Xunit;

namespace TripTime.API.Tests.Hotels
{
    public class HotelControllerTests
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper<Hotel, HotelDTO_Create, HotelDTO_Return> _hotelMapper;
        private readonly HotelsController _hotelController;

        public HotelControllerTests()
        {
            _hotelService = Substitute.For<IHotelService>();
            _hotelMapper = Substitute.For<IMapper<Hotel, HotelDTO_Create, HotelDTO_Return>>();
            _hotelController = new HotelsController(_hotelMapper, _hotelService);
        }

        [Fact]
        public async Task GivenCompletHotelDto_WhenCreatingNewHotel_ThenReturnStatusCode201WithHotel()
        {
            //Given
            AddressDTO_Create newAddressDto = new AddressDTO_Create()
            {
                ZipCode = 1820,
                City = "TestCity",
                Country = "TestCountry",
                StreetName = "TestStreetName",
                StreetNumber = "TestNumberA"
            };

            HotelDTO_Create newHotelDto = new HotelDTO_Create()
            {
                Address = newAddressDto,
                Website = "TestWebsite",
                ContactPerson = "Test contact Person"
            };

            var newHotel = Hotel.CreateNewHotel(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "TestName",
                "Test Website",
                "Test ContactPerson");

            _hotelService.Create(_hotelMapper.DtoToDomain(newHotelDto)).Returns(newHotel.Id.ToString());

            //When
            var result = await _hotelController.CreateNewHotel(newHotelDto);

            CreatedResult c = (CreatedResult)result.Result;

            //then
            Assert.Equal(201, c.StatusCode);
            Assert.Contains(newHotel.Id.ToString(), c.Location.ToString());
        }

        [Fact]
        public async Task GivenListHotelsDto_WhenGetAll_ThenReturnOKWithList()
        {
            //Given
            Hotel hotel = Hotel.CreateNewHotel(Guid.NewGuid(),
                Guid.NewGuid(),
                "TestName",
                "test website",
                "Test contactPerson");

            List<Hotel> listHotel = new List<Hotel>() { hotel };

            _hotelService.GetAllHotels().Returns(listHotel);

            //When
            var taskResult = await _hotelController.GetAllHotels();
            OkObjectResult okResult = (OkObjectResult)taskResult.Result;
           
            //then
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GivenListHotelDto_WhenGetOneById_ThenReturnOKWithOne()
        {
            //Given
            var newHotel = Hotel.CreateNewHotel(
                Guid.NewGuid(),
                Guid.NewGuid(), 
                "TestName",
                "Test Website",
                "Test ContactPerson");
            
            _hotelService.GetHotelById(newHotel.Id).Returns(newHotel);
            _hotelMapper.DomainToDto(newHotel).Returns(new HotelDTO_Return());

            //When
            var okTask = await _hotelController.GetById(newHotel.Id.ToString());
            OkObjectResult ok = (OkObjectResult)okTask.Result;

            //then
            Assert.Equal(200, ok.StatusCode);
        }

    }
}

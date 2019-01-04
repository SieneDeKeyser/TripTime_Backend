using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.Exceptions;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.Trips.Hotels;
using Xunit;

namespace TripTime.Service.Tests.Trips
{
    public class HotelServiceTests
    {
        private readonly IRepository<Hotel> _repository;
        private readonly IHotelService _service;

        public HotelServiceTests()
        {
            _repository = Substitute.For<IRepository<Hotel>>();
            _service = new HotelService(_repository);
        }

        [Fact]
        public void GivenNewHotel_WhenCreatingNewHotel_ThenRepositorySaveIsCalled()
        {
            //Given
            Hotel newHotel = Hotel.CreateNewHotel(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "TestName",
                "TestWebsite",
                "Test contact Person");

            //when
            _service.Create(newHotel);

            //then
            _repository.Received().Save(newHotel);
        }

        [Fact]
        public void GivenIdHotel_WhenGetHotelById_ThenRpositorytGetByIdIsCalles()
        {
            //Given
            Hotel newHotel = Hotel.CreateNewHotel(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "TestName",
                "TestWebsite",
                "Test contact Person");

            //When
            _service.GetHotelById(newHotel.Id);

            //Then
            _repository.Received().GetById(newHotel.Id);
        }

        [Fact]
        public async void GivenNonExistingIdHotel_WhenGetHotelById_ThenThrowObjectNotfoundException()
        {
            //Given
            Hotel fakeHotel = Hotel.CreateNewHotel(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "TestName",
                "TestWebsite",
                "Test contact Person");

            _repository.GetById(fakeHotel.Id).ReturnsNull();

            //Then
            await Assert.ThrowsAsync<ObjectNotFoundException>(()=> _service.GetHotelById(fakeHotel.Id));
        }

        [Fact]
        public void GivenHotelList_WhenGetAllHotels_ThenRpositorytGetAllIsCalles()
        {
            //Given

            //When
            _service.GetAllHotels();

            //Then
            _repository.Received().GetAll();
        }
    }
}

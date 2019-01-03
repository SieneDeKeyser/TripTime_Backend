using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.Exceptions;
using Xunit;

namespace TripTime.Domain.Tests.Trips
{
    public class HotelTests
    {
        [Fact]
        public void GivenNewhotelWithNoContactPerson_WhenCreatingNewHotel_ThenThrowObjectNotValidException()
        {
            //given
            //when
            Action act = () => Hotel.CreateNewHotel(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "TestWebsite",
                "");

            //Then
            Assert.Throws<ObjectNotValidException>(act);
        }

        [Fact]
        public void GivenNewhotelWithNoWebsite_WhenCreatingNewHotel_ThenThrowObjectNotValidException()
        {
            //given
            //when
            Action act = () => Hotel.CreateNewHotel(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "",
                "Test contactPerson");

            //Then
            Assert.Throws<ObjectNotValidException>(act);
        }

        [Fact]
        public void GivenNewhotelWithEmptyGuid_WhenCreatingNewHotel_ThenThrowObjectNotValidException()
        {
            //given
            //when
            Action act = () => Hotel.CreateNewHotel(
                Guid.Empty,
                Guid.NewGuid(),
                "TestWebsite",
                "Test contactPerson");

            //Then
            Assert.Throws<ObjectNotValidException>(act);
        }

        [Fact]
        public void GivenNewhotelWithAllPropertiesNeeded_WhenCreatingNewHotel_ThenReturnNewHotel()
        {
            //given
            var id = Guid.NewGuid();
            var idAddress = Guid.NewGuid();
            var website = "Test Website";
            var contactPerson = "Test ContactPerson";

            //when
            var newHotel = Hotel.CreateNewHotel(
                id,
                idAddress,
                website,
                contactPerson);

            //Then
            Assert.IsType<Hotel>(newHotel);
        }
    }
}

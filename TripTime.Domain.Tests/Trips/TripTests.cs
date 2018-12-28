using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Domain.Trips;
using TripTime.Domain.Trips.ExtraTripPackages;
using Xunit;

namespace TripTime.Domain.Tests.Trips
{
   public class TripTests
    {
        [Fact]
        public void GivenTripWithBasicPrice2000_WhenAllInclusive_ThenPriceIsAugmentedWith5000()
        {
            //Given
            var newTrip = Trip.CreateNewTrip(
                Guid.NewGuid(), 
                10,
                Guid.NewGuid(),
                2000,
                "test schedule",
                Transport.Flight);

            //when
            Allinclusive tripAllinclusive = new Allinclusive(newTrip);

            //then
            Assert.Equal(7000, tripAllinclusive.BasicPrice);

        }

        [Fact]
        public void GivenTripWithBasicPrice2000_WhenHalfPension_ThenPriceIsAugmentedWith1500()
        {
            //Given
            var newTrip = Trip.CreateNewTrip(
                Guid.NewGuid(),
                10,
                Guid.NewGuid(),
                2000,
                "test schedule",
                Transport.Flight);

            //when
            HalfPension tripAllinclusive = new HalfPension(newTrip);

            //then
            Assert.Equal(3500, tripAllinclusive.BasicPrice);

        }
    }
}

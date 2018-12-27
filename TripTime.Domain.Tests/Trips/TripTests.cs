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
            ////Given
            //var newTrip = TripBuilder.NewTripBuilder()
            //    .WithId(Guid.NewGuid())
            //    .WithTransportType(Transport.Bus)
            //    .WithSchedule("test schedule")
            //    .WithBasicPrice(2000)
            //    .WithCapacity(10)
            //    .WithHotelId(Guid.NewGuid())
            //    .Build();

            ////when
            //Allinclusive tripAllinclusive = (Allinclusive) newTrip;

            ////then
            //Assert.Equal(7000, tripAllinclusive.BasicPrice);
          
        }
    }
}

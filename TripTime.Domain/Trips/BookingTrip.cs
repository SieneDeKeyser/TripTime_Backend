using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Domain.Trips
{
   public class BookingTrip
    {
        public Guid Id { get; private set; }
        public Guid TripScheduleId { get; private set; }
        public Guid ClientId { get; private set; }
        //public Client Client { get; private set; }
        public decimal TotalPrice { get; private set; }
    }
}

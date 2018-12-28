using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Domain.Trips
{
   public class BookingTrip
    {
        public Guid Id { get; private set; }
        public Guid TripScheduleId { get; private set; }
        public TripSchedule TripSchedule { get; private set; }
        public Guid ClientId { get; private set; }
        //public Client Client { get; private set; }
        public decimal TotalPrice { get; private set; }

        private BookingTrip(){}
        private BookingTrip(Guid id, Guid tripScheduleId, Guid clientId, decimal totalPrice)
        {
            Id = id;
            TripScheduleId = tripScheduleId;
            ClientId = clientId;
            TotalPrice = totalPrice;
        }

        public static BookingTrip CreateNewBookingTrip(Guid id, Guid tripScheduleId, Guid clientId, decimal totalPrice)
        {
            return new BookingTrip(id, tripScheduleId, clientId, totalPrice);
        }
    }
}

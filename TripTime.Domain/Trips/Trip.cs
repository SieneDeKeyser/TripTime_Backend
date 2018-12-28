using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Domain.Files;

namespace TripTime.Domain.Trips
{
    public class Trip
    {
        public Guid Id { get; private set; }
        public int Capacity { get; private set; }
        public Guid HotelId { get; private set; }
        public Hotel Hotel { get; private set; }
        public virtual decimal BasicPrice { get; private set; }
        public IList<Image> Images { get; private set; }
        public string Schedule { get; private set; }
        public Transport TransportType { get; private set; }

        protected Trip(){}
        protected Trip(int capacity, Guid hotelId, decimal basicPrice, string schedule, Transport transportType)
        {
            Id = Guid.NewGuid();
            Capacity = capacity;
            HotelId = hotelId;
            BasicPrice = basicPrice;
            Schedule = schedule;
            TransportType = transportType;
        }

        public static Trip CreateNewTrip(int capacity, Guid hotelId, decimal basicPrice, string schedule, Transport transportType)
        {
            return new Trip(capacity, hotelId, basicPrice, schedule, transportType);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Domain.Files;
using TripTime.Infrastructure.Builders;

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
        protected Trip(Guid id, int capacity, Guid hotelId, decimal basicPrice, string schedule, Transport transportType)
        {
            Id = id;
            Capacity = capacity;
            HotelId = hotelId;
            BasicPrice = basicPrice;
            Schedule = schedule;
            TransportType = transportType;
        }

        public static Trip CreateNewTrip(Guid id, int capacity, Guid hotelId, decimal basicPrice, string schedule, Transport transportType)
        {
            return new Trip(id, capacity, hotelId, basicPrice, schedule, transportType);
        }
    }
}


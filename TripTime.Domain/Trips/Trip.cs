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
        public TripBuilder builder { get; set; }

        public Trip()
        {
            Id = builder.Id;
            Capacity = builder.Capacity;
            HotelId = builder.HotelId;
            BasicPrice = builder.BasicPrice;
            Schedule = builder.Schedule;
            TransportType = builder.TransportType;
        }
    }
    public class TripBuilder: Builder<Trip>
    {
        public Guid Id { get; private set; }
        public int Capacity { get; private set; }
        public Guid HotelId { get; private set; }
        public decimal BasicPrice { get; private set; }
        public string Schedule { get; private set; }
        public Transport TransportType { get; private set; }

        public static TripBuilder NewTripBuilder()
        {
            return new TripBuilder();
        }

        public TripBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public TripBuilder WithHotelId(Guid hotelId)
        {
            HotelId= hotelId;
            return this;
        }

        public TripBuilder WithCapacity(int capacity)
        {
            Capacity = capacity;
            return this;
        }

        public TripBuilder WithBasicPrice(decimal basicPrice)
        {
            BasicPrice = basicPrice;
            return this;
        }

        public TripBuilder WithSchedule(string schedule)
        {
            Schedule= schedule;
            return this;
        }

        public TripBuilder WithTransportType(Transport type)
        {
            TransportType = type;
            return this;
        }
    }
}


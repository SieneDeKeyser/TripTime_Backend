using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Infrastructure.Builders;

namespace TripTime.Domain.Trips
{
   public class TripSchedule
    {
        public Guid Id { get; private set; }
        public Guid TripId { get; private set; }
        public Trip Trip { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string DeparturePlace { get; private set; }
        public string ReturnPlace { get; private set; }
        public TripScheduleBuilder builder { get; set; }

        public TripSchedule()
        {
            Id = builder.Id;
            TripId = builder.TripId;
            StartDate = builder.StartDate;
            EndDate = builder.EndDate;
            DeparturePlace = builder.DeparturePlace;
            ReturnPlace = builder.ReturnPlace;
        }
    }

    public class TripScheduleBuilder: Builder<TripSchedule>
    {
        public Guid Id { get; private set; }
        public Guid TripId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string DeparturePlace { get; private set; }
        public string ReturnPlace { get; private set; }

        public static TripScheduleBuilder NewTripScheduleBuilder() {
            return new TripScheduleBuilder();
        }

        public TripScheduleBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }
        public TripScheduleBuilder WithTripId(Guid tripId)
        {
            TripId = tripId;
            return this;
        }
        public TripScheduleBuilder WithStartDate(DateTime startDate)
        {
            StartDate = startDate;
            return this;
        }
        public TripScheduleBuilder WithId(DateTime endDate)
        {
            EndDate = endDate;
            return this;
        }
        public TripScheduleBuilder WithDepartureDate(string departurePlace)
        {
            DeparturePlace = departurePlace;
            return this;
        }
        public TripScheduleBuilder WithReturnPlace(string returnPlace)
        {
            ReturnPlace = returnPlace;
            return this;
        }
    }
}

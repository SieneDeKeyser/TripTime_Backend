using System;
using System.Collections.Generic;
using System.Text;

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

        private TripSchedule(){}

        private TripSchedule(Guid id, Guid tripId, DateTime startDate, DateTime endDate, string departurePlace, string returnPlace)
        {
            Id = id;
            TripId = tripId;
            StartDate = startDate;
            EndDate = endDate;
            DeparturePlace = departurePlace;
            ReturnPlace = returnPlace;
        }

        public static TripSchedule CreateNewTripSchedule(Guid id, Guid tripId, DateTime startDate, DateTime endDate, string departurePlace, string returnPlace)
        {
            return new TripSchedule(id, tripId, startDate, endDate, departurePlace, returnPlace);
        }
    }

}

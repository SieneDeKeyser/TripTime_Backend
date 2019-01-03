using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.Domain.Trips;

namespace TripTime.API.Trips.DTO.Trips
{
    public class TripDTO_Create
    {
        public int Capacity { get; set; }
        public Guid HotelId { get; set; }
        public virtual decimal BasicPrice { get; set; }
        public string Schedule { get; set; }
        public Transport TransportType { get; set; }
    }
}

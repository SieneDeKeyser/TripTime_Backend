using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.Domain.Files;
using TripTime.Domain.Trips;

namespace TripTime.API.Trips.DTO
{
    public class TripDTO_Return
    {
        public Guid Id { get; set; }
        public int Capacity { get; set; }
        public Hotel Hotel { get; set; }
        public virtual decimal BasicPrice { get; set; }
        public IList<Image> Images { get; set; }
        public string Schedule { get; set; }
        public Transport TransportType { get; set; }
    }
}

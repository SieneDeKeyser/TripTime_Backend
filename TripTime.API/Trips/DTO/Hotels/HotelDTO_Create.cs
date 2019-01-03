using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;
using TripTime.Domain.ContactInformation;

namespace TripTime.API.Trips.DTO.Hotels
{
    public class HotelDTO_Create
    {
        public AddressDTO_Create Address { get; set; }
        public string Website { get; set; }
        public string ContactPerson { get; set; }
    }
}

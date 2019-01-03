using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;

namespace TripTime.API.Trips.DTO.Hotels
{
    public class HotelDTO_Return
    {
        public AddressDTO_Return Address { get; set; }
        public string Website { get; set; }
        public string ContactPerson { get; set; }
    }
}

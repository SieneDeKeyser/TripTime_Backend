using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTime.API.ContactInformation.DTO
{
    public class AddressDTO_Create
    {
        public int ZipCode { get;  set; }
        public string City { get;  set; }
        public string Country { get;  set; }
        public string StreetName { get;  set; }
        public string StreetNumber { get;  set; }
    }
}

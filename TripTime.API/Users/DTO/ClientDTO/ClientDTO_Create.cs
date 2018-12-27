using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;

namespace TripTime.API.Users.DTO.ClientDTO
{
    public class ClientDTO_Create
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AddressDTO_Create AddressDTO { get; set; }
        public string Rating { get; set; }
        
    }
}

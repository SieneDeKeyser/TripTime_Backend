using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;
using TripTime.API.Users.DTO.UserDTO;

namespace TripTime.API.Users.DTO.ClientDTO
{
    public class ClientDTO_Create
    {
        public UserDTO_Create UserDTO { get; set; }
        public AddressDTO_Create AddressDTO { get; set; }
        public string Rating { get; set; }        
    }
}

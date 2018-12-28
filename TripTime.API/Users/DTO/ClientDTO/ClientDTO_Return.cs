using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;
using TripTime.API.Users.DTO.UserDTO;

namespace TripTime.API.Users.DTO.ClientDTO
{
    public class ClientDTO_Return
    {      
        public UserDTO_Return UserDTO { get; set; }
        public AddressDTO_Return AddressDTO { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Rating { get; set; }
    }
}

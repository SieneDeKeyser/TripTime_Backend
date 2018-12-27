using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;

namespace TripTime.API.Users.DTO.ClientDTO
{
    public class ClientDTO_Return
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressDTO_Return AddressDTO { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Rating { get; set; }
    }
}

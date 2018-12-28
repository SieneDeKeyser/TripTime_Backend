using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTime.API.Users.DTO.UserDTO
{
    public class UserDTO_Create
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LoginDTO LoginDTO { get; set; }
    }
}

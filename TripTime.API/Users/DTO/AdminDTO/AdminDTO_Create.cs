using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.Users.DTO.UserDTO;

namespace TripTime.API.Users.DTO.AdminDTO
{
    public class AdminDTO_Create
    {
        public UserDTO_Create UserDTO { get; set; }
    }
}

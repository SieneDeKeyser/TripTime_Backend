using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTime.API.Users.DTO.AdminDTO
{
    public class AdminDTO_Return
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

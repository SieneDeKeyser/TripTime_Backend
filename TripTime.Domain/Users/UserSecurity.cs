using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Domain.Users
{
    public class UserSecurity
    {
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public UserSecurity(string passwordHash, string salt)
        {
            PasswordHash = passwordHash;
            Salt = salt;
        }
    }
}
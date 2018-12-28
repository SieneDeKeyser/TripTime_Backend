using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace TripTime.Domain.Users
{
    public class Admin : User
    {
        private Admin():base(){}
        private Admin(string firstName, string lastName, MailAddress email, UserSecurity securePassword) : base(firstName, lastName, email, securePassword)
        {}

        public static Admin CreateNewAdmin(string firstName, string lastName, MailAddress email, UserSecurity securePassword)
        {
            return new Admin(firstName, lastName, email, securePassword);
        }
    }
}

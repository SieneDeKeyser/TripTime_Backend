using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace TripTime.Domain.Users
{
    public abstract class User
    {
        public Guid Id { get; private set; }
        public MailAddress Email { get; private set; }
        public UserSecurity SecurePassword { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private User() { }

        public User(string firstName, string lastName, MailAddress email, UserSecurity securePassword)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            SecurePassword = securePassword;
        }
    }
}

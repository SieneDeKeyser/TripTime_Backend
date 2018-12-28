using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using TripTime.Domain.ContactInformation;

namespace TripTime.Domain.Users
{
    public class Client : User
    {
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string Rating { get; private set; }

        private Client():base(){}
        
        private Client(string firstName, string lastName, MailAddress email, UserSecurity securePassword, Address givenAddress, string rating) : base(firstName, lastName, email, securePassword)
        {
            Address = givenAddress;
            Rating = rating;
            RegistrationDate = DateTime.Now;
        }


        public static Client CreateNewClient(string firstName, string lastName, MailAddress email, UserSecurity securePassword, Address givenAddress, string rating)
        {
            return new Client(firstName, lastName, email, securePassword, givenAddress, rating);
        }

    }
}

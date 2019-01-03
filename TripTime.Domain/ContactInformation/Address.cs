using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Infrastructure.Exceptions;

namespace TripTime.Domain.ContactInformation
{
    public class Address
    {
        public Guid Id { get; private set; }
        public int ZipCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string StreetName { get; private set; }
        public string StreetNumber { get; private set; }

        private Address()
        {}

        private Address(int zipCode, string city, string country, string streetName, string streetNumber)
        {
            Id = Guid.NewGuid();
            ZipCode = zipCode;
            City = city;
            Country = country;
            StreetName = streetName;
            StreetNumber = streetNumber;
        }

        public static Address CreateNewAddress(int zipCode, string city, string country, string streetName, string streetNumber)
        {
            if (zipCode == 0 || 
                string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(country) ||
                string.IsNullOrEmpty(streetName) ||
                string.IsNullOrEmpty(streetNumber))
            {
                throw new ObjectNotValidException("Some fields can not be empty or whiteSpace when creating this new address", new Address());
            }
            return new Address(zipCode, city, country, streetName, streetNumber);
        }
    }

}

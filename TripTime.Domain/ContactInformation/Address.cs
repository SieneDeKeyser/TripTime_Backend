﻿using System;
using System.Collections.Generic;
using System.Text;

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

        private Address(Guid id, int zipCode, string city, string country, string streetName, string streetNumber)
        {
            Id = id;
            ZipCode = zipCode;
            City = city;
            Country = country;
            StreetName = streetName;
            StreetNumber = streetNumber;
        }
        
        public static Address CreateNewAddress(Guid id, int zipCode, string city, string country, string streetName, string streetNumber)
        {
            return new Address(id, zipCode, city, country, streetName, streetNumber);
        }
    }

}

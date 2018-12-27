using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Infrastructure.Builders;

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
        public AddressBuilder builder { get; set; }

        public Address()
        {
            Id = builder.Id;
            ZipCode = builder.ZipCode;
            City = builder.City;
            Country = builder.Country;
            StreetNumber = builder.StreetName;
            StreetNumber = builder.StreetNumber;
        }
    }

    public class AddressBuilder : Builder<Address>
    {
        public Guid Id { get; private set; }
        public int ZipCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string StreetName { get; private set; }
        public string StreetNumber { get; private set; }

        public static AddressBuilder newAddressBuilder()
        {
            return new AddressBuilder();
        }

        public AddressBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public AddressBuilder WithZipCode(int zipCode)
        {
            ZipCode = zipCode;
            return this;
        }

        public AddressBuilder WithCity(string cityName)
        {
            City = cityName;
            return this;
        }
        public AddressBuilder WithCountry(string countryName)
        {
            Country = countryName;
            return this;
        }

        public AddressBuilder WithStreetName(string streetName)
        {
            StreetName = streetName;
            return this;
        }

        public AddressBuilder WithStreetNumber(string streetNumber)
        {
            StreetNumber = streetNumber;
            return this;
        }

    }
}

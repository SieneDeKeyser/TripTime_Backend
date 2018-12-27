using System;
using TripTime.Domain.ContactInformation;
using TripTime.Infrastructure.Builders;
namespace TripTime.Domain.Trips
{
   public class Hotel
    {
        public Guid Id { get; private set; }
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }
        public string WebSite { get; private set; }
        public string ContactPerson { get; private set; }
        public HotelBuilder builder { get; set; }

        public Hotel()
        {
            Id = builder.Id;
            AddressId = builder.AddressId;
            WebSite = builder.WebSite;
            ContactPerson = builder.ContactPerson;
        }
    }

    public class HotelBuilder: Builder<Hotel>
    {
        public Guid Id { get; private set; }
        public Guid AddressId { get; private set; }
        public string WebSite { get; private set; }
        public string ContactPerson { get; private set; }

        public static HotelBuilder NewHotelBuilder()
        {
            return new HotelBuilder();
        }

        public HotelBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public HotelBuilder WithAddressId(Guid id)
        {
            AddressId = id;
            return this;
        }

        public HotelBuilder WithWebsite(string website)
        {
            WebSite = website;
            return this;
        }

        public HotelBuilder WithContactPerson(string contactPerson)
        {
            ContactPerson = contactPerson;
            return this;
        }
    }
}

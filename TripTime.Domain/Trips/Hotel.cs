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
        public string Website { get; private set; }
        public string ContactPerson { get; private set; }

        private Hotel(){}

        private Hotel(Guid id, Guid addressId, string website, string contactPerson)
        {
            Id = id;
            AddressId = addressId;
            Website = website;
            ContactPerson = contactPerson;
        }

        public static Hotel CreateNewHotel(Guid id, Guid addressId, string website, string contactPerson)
        {
            return new Hotel(id, addressId, website, contactPerson);
        }
    }

}

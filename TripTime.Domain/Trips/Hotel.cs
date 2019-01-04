using System;
using TripTime.Domain.ContactInformation;
using TripTime.Infrastructure.Exceptions;

namespace TripTime.Domain.Trips
{
   public class Hotel
    {
        public Guid Id { get; private set; }
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }
        public string Website { get; private set; }
        public string ContactPerson { get; private set; }
        public string Name{ get;private set; }

        private Hotel(){}

        private Hotel(Guid id, Guid addressId, string website, string contactPerson, string name)
        {
            Id = id;
            AddressId = addressId;
            Website = website;
            ContactPerson = contactPerson;
            Name = name;
        }

        public static Hotel CreateNewHotel(Guid id, Guid addressId,string name, string website, string contactPerson)
        {
            if (Guid.Empty == id || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(website) || string.IsNullOrEmpty(contactPerson))
            {
                throw new ObjectNotValidException("Some fields can not be empty or whiteSpace when creating this new hotel", new Hotel());
            }
            return new Hotel(id, addressId, website, contactPerson, name);
        }
    }

}

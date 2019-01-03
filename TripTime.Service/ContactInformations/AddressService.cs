using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Domain.ContactInformation;
using TripTime.Infrastructure.Exceptions;
using TripTime.Infrastructure.GlobalInterfaces;

namespace TripTime.Service.ContactInformations
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<string> Create(Address address)
        {
            await _addressRepository.Save(address);
            return address.Id.ToString();
        }

        public async Task<Address> GetAddressById(Guid id)
        {
            var address = await _addressRepository.GetById(id);
            if (address == null)
            {
                throw new ObjectNotFoundException("Searching address by id", "Address", id);
            }
            return address;
        }
    }
}

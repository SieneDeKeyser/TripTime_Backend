using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Domain.ContactInformation;

namespace TripTime.Service.ContactInformations
{
    public interface IAddressService
    {
        Task<string> Create(Address address);
        Task<Address> GetAddressById(Guid id);
    }
}

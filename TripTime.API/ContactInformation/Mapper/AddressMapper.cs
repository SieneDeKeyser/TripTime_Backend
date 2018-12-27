using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;
using TripTime.Domain.ContactInformation;
using TripTime.Infrastructure.GlobalInterfaces;

namespace TripTime.API.ContactInformation.Mapper
{
    public class AddressMapper : IMapper<Address, AddressDTO_Create, AddressDTO_Return>
    {
        public AddressDTO_Return DomainToDto(Address givenDomainObject)
        {
            throw new NotImplementedException();
        }

        public List<Address> DtoListToDomainList(List<AddressDTO_Create> listOfcreateDTOs)
        {
            throw new NotImplementedException();
        }

        public List<AddressDTO_Return> DtoListToDomainList(List<Address> listOfDomainObjects)
        {
            throw new NotImplementedException();
        }

        public Address DtoToDomain(AddressDTO_Create givenDTO)
        {
            throw new NotImplementedException();
        }
    }
}

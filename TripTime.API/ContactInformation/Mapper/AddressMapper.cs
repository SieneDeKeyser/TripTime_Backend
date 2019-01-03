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
            return new AddressDTO_Return()
            {
                City = givenDomainObject.City,
                Country = givenDomainObject.Country,
                StreetName = givenDomainObject.StreetName,
                StreetNumber = givenDomainObject.StreetNumber,
                Id = givenDomainObject.Id,
                ZipCode = givenDomainObject.ZipCode
            };
        }
        public Address DtoToDomain(AddressDTO_Create givenDTO)
        {
            return Address.CreateNewAddress(
                givenDTO.ZipCode,
                givenDTO.City,
                givenDTO.Country,
                givenDTO.StreetName,
                givenDTO.StreetNumber
                );
        }

        public List<Address> DtoListToDomainList(List<AddressDTO_Create> listOfcreateDTOs)
        {
            throw new NotImplementedException();
        }

        public List<AddressDTO_Return> DomainListToDtoList(List<Address> listOfDomainObjects)
        {
            throw new NotImplementedException();
        }

    }
}

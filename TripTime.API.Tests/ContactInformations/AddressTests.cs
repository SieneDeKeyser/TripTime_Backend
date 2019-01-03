using System;
using TripTime.API.ContactInformation.DTO;
using TripTime.API.ContactInformation.Mapper;
using TripTime.Domain.ContactInformation;
using TripTime.Infrastructure.GlobalInterfaces;
using Xunit;

namespace TripTime.API.Tests.ContactInformations
{
   public class AddressTests
    {
        private readonly IMapper<Address, AddressDTO_Create, AddressDTO_Return> _mapper;
        public AddressTests()
        {
            _mapper = new AddressMapper();
        }

        [Fact]
        public void GivenAnAddressDto_Create_WhenMappingToDomain_ThenAddressHasNewGuidId()
        {
            //Given
            AddressDTO_Create newAddressDto = new AddressDTO_Create()
            {
                ZipCode = 1820,
                City = "TestCity",
                Country = "TestCountry",
                StreetName = "TestStreetName",
                StreetNumber = "TestNumberA"
            };

            //when
            var newAddress = _mapper.DtoToDomain(newAddressDto);

            //then
            Assert.IsType<Address>(newAddress);
            Assert.NotEqual(Guid.Empty, newAddress.Id);
        }

        [Fact]
        public void GivenAnAddress_WhenMappingToDto_ThenAddressIsAddressDto_Return()
        {
            //Given
            Address newAddress = Address.CreateNewAddress(
            
                1820,
                "TestCity",
                "TestCountry",
                "TestStreetName",
                "TestNumberA"
            );

            //when
            var newAddressDto = _mapper.DomainToDto(newAddress);

            //then
            Assert.IsType<AddressDTO_Return>(newAddressDto);
        }
    }
}

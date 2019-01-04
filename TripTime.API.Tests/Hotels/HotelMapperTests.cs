using NSubstitute;
using System;
using TripTime.API.ContactInformation.DTO;
using TripTime.API.ContactInformation.Mapper;
using TripTime.API.Trips.DTO.Hotels;
using TripTime.API.Trips.Mapper;
using TripTime.Domain.ContactInformation;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.Exceptions;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.ContactInformations;
using Xunit;

namespace TripTime.API.Tests.Hotels
{
    public class HotelMapperTests
    {
        private IMapper<Address, AddressDTO_Create, AddressDTO_Return> _addressmapper;
        private IMapper<Hotel, HotelDTO_Create, HotelDTO_Return> _hotelmapper;
        private IAddressService _addressService;
        public HotelMapperTests()
        {
            _addressmapper = new AddressMapper();
            _addressService = Substitute.For<IAddressService>();
            _hotelmapper = new HotelMapper(_addressmapper, _addressService);
        }

        [Fact]
        public void GivenHotelDTO_Create_WhenMappingToHotel_ThenReturnNewHotelNewAddress()
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

            HotelDTO_Create newHotelDto = new HotelDTO_Create()
            {
                Address = newAddressDto,
                Website = "TestWebsite",
                ContactPerson = "Test contact Person",
                Name= "Test Name"
            };

            //When
            var newHotel = _hotelmapper.DtoToDomain(newHotelDto);

            //Then
            Assert.IsType<Hotel>(newHotel);
            Assert.NotEqual(Guid.Empty, newHotel.Id);
        }

        [Fact]
        public void GivenHotelDTO_CreateWithNotAllNeededProperties_WhenMappingToHotel_throwObjectNotValidException()
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

            HotelDTO_Create newHotelDto = new HotelDTO_Create()
            {
                Address = newAddressDto,
                Website = "TestWebsite",
                ContactPerson = "Test contact Person",
                Name = ""
            };

            //When
            Action act = () => _hotelmapper.DtoToDomain(newHotelDto);

            //Then
            Assert.Throws<ObjectNotValidException>(act);
        }

        [Fact]
        public void GivenHotel_WhenMappingToHotelDto_ThenReturnHotelDTO_Return()
        {
            _addressmapper = Substitute.For<IMapper<Address, AddressDTO_Create, AddressDTO_Return>>();
            _addressService = Substitute.For<IAddressService>();
            _hotelmapper = new HotelMapper(_addressmapper, _addressService);

            Address newAddress = Address.CreateNewAddress(

              1820,
              "TestCity",
              "TestCountry",
              "TestStreetName",
              "TestNumberA"
            );

            AddressDTO_Return newAddressDtoReturn = new AddressDTO_Return()
            {
                Id = Guid.NewGuid(),
                ZipCode = 1820,
                City = "TestCity",
                Country = "TestCountry",
                StreetName = "TestStreetName",
                StreetNumber = "TestNumberA"
            };

            //Given
            Hotel newHotel = Hotel.CreateNewHotel(

                Guid.NewGuid(),
                newAddress.Id,
                "TestName",
                "TestWebsite",
                "Test contact Person");

            _addressmapper.DomainToDto(null).Returns(newAddressDtoReturn);

            //When
            var newHotelDto = _hotelmapper.DomainToDto(newHotel);

            //Then
            Assert.IsType<HotelDTO_Return>(newHotelDto);
        }
    }
}

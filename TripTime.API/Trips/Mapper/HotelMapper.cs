using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;
using TripTime.API.ContactInformation.Mapper;
using TripTime.API.Trips.DTO.Hotels;
using TripTime.Domain.ContactInformation;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.ContactInformations;

namespace TripTime.API.Trips.Mapper
{
    public class HotelMapper : IMapper<Hotel, HotelDTO_Create, HotelDTO_Return>
    {
        private readonly IMapper<Address, AddressDTO_Create, AddressDTO_Return> _addressMapper;
        private readonly IAddressService _addressService;

        public HotelMapper(IMapper<Address, AddressDTO_Create, AddressDTO_Return> addressMapper, IAddressService addressService)
        {
            _addressMapper = addressMapper;
            _addressService = addressService;
        }

        public HotelDTO_Return DomainToDto(Hotel givenDomainObject)
        {
            return new HotelDTO_Return
            {
                Address = _addressMapper.DomainToDto(givenDomainObject.Address),
                Website = givenDomainObject.Website,
                ContactPerson = givenDomainObject.ContactPerson,
                Name=givenDomainObject.Name
            };
        }

        public List<Hotel> DtoListToDomainList(List<HotelDTO_Create> listOfcreateDTOs)
        {
            return listOfcreateDTOs.Select(hotelDto => { return DtoToDomain(hotelDto); }).ToList();
        }

        public List<HotelDTO_Return> DomainListToDtoList(List<Hotel> listOfDomainObjects)
        {
            return listOfDomainObjects.Select(hotelDomain => { return DomainToDto(hotelDomain); }).ToList();
        }

        public Hotel DtoToDomain(HotelDTO_Create givenDTO)
        {
            Address newAddress = _addressMapper.DtoToDomain(givenDTO.Address);
            _addressService.Create(newAddress);
            return Hotel.CreateNewHotel(
                Guid.NewGuid(),
                newAddress.Id,
                givenDTO.Name,
                givenDTO.Website,
                givenDTO.ContactPerson);
        }
    }
}

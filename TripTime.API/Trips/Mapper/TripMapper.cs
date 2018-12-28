using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.Trips.DTO;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.GlobalInterfaces;

namespace TripTime.API.Trips.Mapper
{
    public class TripMapper : IMapper<Trip, TripDTO_Create, TripDTO_Return>
    {
        public TripDTO_Return DomainToDto(Trip givenDomainObject)
        {
            return new TripDTO_Return()
            {
                Id = givenDomainObject.Id,
                Capacity = givenDomainObject.Capacity,
                Hotel = givenDomainObject.Hotel,
                BasicPrice = givenDomainObject.BasicPrice,
                Images = givenDomainObject.Images,
                Schedule = givenDomainObject.Schedule,
                TransportType = givenDomainObject.TransportType
            };
        }

        public List<Trip> DtoListToDomainList(List<TripDTO_Create> listOfcreateDTOs)
        {
            return listOfcreateDTOs.Select(
                tripDtoCreate => { return DtoToDomain(tripDtoCreate); })
                .ToList();
        }

        public List<TripDTO_Return> DtoListToDomainList(List<Trip> listOfDomainObjects)
        {
            return listOfDomainObjects.Select(
                trip => { return DomainToDto(trip); })
                .ToList();
        }

        public Trip DtoToDomain(TripDTO_Create givenDTO)
        {
            return Trip.CreateNewTrip(givenDTO.Capacity, givenDTO.HotelId, givenDTO.BasicPrice, givenDTO.Schedule, givenDTO.TransportType);
        }
    }
}

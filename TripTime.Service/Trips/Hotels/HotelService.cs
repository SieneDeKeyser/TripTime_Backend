using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Domain.ContactInformation;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.Exceptions;
using TripTime.Infrastructure.GlobalInterfaces;

namespace TripTime.Service.Trips.Hotels
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> _hotelRepository;

        public HotelService(IRepository<Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<string> Create(Hotel hotel)
        {
            await _hotelRepository.Save(hotel);
            return hotel.Id.ToString();
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _hotelRepository.GetAll();
        }

        public async Task<Hotel> GetHotelById(Guid id)
        {
            var hotel =  await _hotelRepository.GetById(id);
            if (hotel == null)
            {
                throw new ObjectNotFoundException("Searching hotel by id", "Hotel", id);
            }
            return hotel;
        }
    }
}

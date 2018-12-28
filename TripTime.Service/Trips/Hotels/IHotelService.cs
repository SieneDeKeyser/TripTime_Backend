using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Domain.Trips;

namespace TripTime.Service.Trips.Hotels
{
    public interface IHotelService
    {
        Task<string> Create(Hotel trip);
        Task<Hotel> GetHotelById(Guid id);
        Task<List<Hotel>> GetAllHotels();
    }
}

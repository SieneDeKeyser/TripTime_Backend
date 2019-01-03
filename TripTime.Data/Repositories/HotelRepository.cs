using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Data.Contexts;
using TripTime.Domain.Trips;
using TripTime.Infrastructure.GlobalInterfaces;

namespace TripTime.Data.Repositories
{
    public class HotelRepository : IRepository<Hotel>
    {
        private readonly TripTimeContext _context;

        public HotelRepository(TripTimeContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAll()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetById(Guid id)
        {
            var t= await _context.Hotels
                                 .Include(hotel => hotel.Address)
                                 .FirstOrDefaultAsync(hotel => hotel.Id == id);

            return t;
        }

        public async Task<Hotel> Save(Hotel newHotel)
        {
            _context.Add(newHotel);
            await _context.SaveChangesAsync();
            return newHotel;
        }

        public async Task<Hotel> update(Hotel hotelToUpdate)
        {
            _context.Update(hotelToUpdate);
            await _context.SaveChangesAsync();
            return hotelToUpdate;
        }
    }
}

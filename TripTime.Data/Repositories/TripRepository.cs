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
    public class TripRepository : IRepository<Trip>
    {
        private readonly TripTimeContext _context;

        public TripRepository(TripTimeContext context)
        {
            _context = context;
        }

        public async Task<List<Trip>> GetAll()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<Trip> GetById(Guid id)
        {
            return await _context.Trips.FirstOrDefaultAsync(trip => trip.Id == id);
        }

        public async Task<Trip> Save(Trip newTrip)
        {
            _context.Add(newTrip);
            await _context.SaveChangesAsync();
            return newTrip;
        }

        public async Task<Trip> update(Trip tripToUpdate)
        {
            _context.Update(tripToUpdate);
            await _context.SaveChangesAsync();
            return tripToUpdate;
        }
    }
}

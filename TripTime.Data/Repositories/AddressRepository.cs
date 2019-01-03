using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Data.Contexts;
using TripTime.Domain.ContactInformation;
using TripTime.Infrastructure.GlobalInterfaces;

namespace TripTime.Data.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly TripTimeContext _context;

        public AddressRepository(TripTimeContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAll()
        {
            return await _context.Set<Address>().ToListAsync();
        }

        public async Task<Address> GetById(Guid id)
        {
            return await _context.Set<Address>().FirstOrDefaultAsync(address => address.Id == id); ;
        }

        public async Task<Address> Save(Address newAddress)
        {
            _context.Add(newAddress);
            await _context.SaveChangesAsync();
            return newAddress;
        }

        public async Task<Address> update(Address addressToUpdate)
        {
            _context.Update(addressToUpdate);
            await _context.SaveChangesAsync();
            return addressToUpdate;
        }
    }
}

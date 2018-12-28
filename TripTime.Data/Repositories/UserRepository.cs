using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTime.Data.Contexts;
using TripTime.Domain.ContactInformation;
using TripTime.Domain.Users;

namespace TripTime.Data.Repositories
{
    public class UserRepository
    {
        private readonly TripTimeContext _context;

        public UserRepository(TripTimeContext context)
        {
            _context = context;
        }


        public async Task<User> Save(User userToCreate)
        {
            _context.Add(userToCreate);
            await _context.SaveChangesAsync();
            return userToCreate;
        }


        public async Task<Admin> GetAdminById(Guid givenId)
        {
            return await _context.Set<Admin>().SingleOrDefaultAsync(admin => admin.Id == givenId);
        }
        public async Task<Client> GetClientById(Guid givenId)
        {
            return await _context.Set<Client>().Include(client => client.Address).SingleOrDefaultAsync(client => client.Id == givenId);
        }


        public async Task<User> Update(User userToUpdate)
        {
            _context.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userToUpdate.Id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindByEmail(string givenEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Address == givenEmail);
        }
    }
}

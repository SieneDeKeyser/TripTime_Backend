using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTime.Data.Contexts;
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

        public async Task<User> Create(User userToCreate)
        {
            _context.Add(userToCreate);
            await _context.SaveChangesAsync();
            return userToCreate;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> Update(User userToUpdate)
        {
            _context.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userToUpdate.Id);
        }

        public User FindByEmail(string givenEmail)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Address == givenEmail);
        }       
    }
}

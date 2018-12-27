using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Data.Repositories;
using TripTime.Domain.Users;

namespace TripTime.Service.Users
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Create(User user)
        {
            await _userRepository.Create(user);
            return user.Id.ToString();
        }        

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }
    }
}

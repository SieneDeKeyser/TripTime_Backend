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


        public async Task<string> CreateNew(User user)
        {
            await _userRepository.Save(user);
            return user.Id.ToString();
        }

        public async Task<Admin> GetAdminById(string id)
        {
            Guid givenId = Guid.Parse(id);

            var foundUser = await _userRepository.GetAdminById(givenId);
            if (foundUser == null)
            { return null; }
            else
            { return foundUser; }
        }      

        public async Task<Client> GetClientById(string id)
        {
            Guid givenId = Guid.Parse(id);

            var foundUser = await _userRepository.GetClientById(givenId);
            if (foundUser == null)
            { return null; }
            else
            { return foundUser; }
        }
    }
}

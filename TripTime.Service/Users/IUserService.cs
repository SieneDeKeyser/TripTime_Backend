using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Domain.Users;

namespace TripTime.Service.Users
{
    public interface IUserService
    {
        Task<string> CreateNew(User user);       
        Task<Admin> GetAdminById(string id);
        Task<Client> GetClientById(string id);
    }
}

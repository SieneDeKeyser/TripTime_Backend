using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripTime.Domain.Users;

namespace TripTime.Service.Users
{
    public interface IUserService
    {
        Task<string> Create(User user);
        Task<User> GetAdminById(Guid id);        
        Task<User> GetClientById(Guid id);
    }
}

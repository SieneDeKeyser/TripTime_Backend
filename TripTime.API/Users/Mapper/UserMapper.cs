using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTime.API.Users.DTO.UserDTO;
using TripTime.Domain.Users;

namespace TripTime.API.Users.Mapper
{
    public class UserMapper
    {
        public UserDTO_Return DomainToDto(User givenDomainObject)
        {
            return new UserDTO_Return
            {
                Id = givenDomainObject.Id.ToString(),
                FirstName = givenDomainObject.FirstName,
                LastName = givenDomainObject.LastName,
                Email = givenDomainObject.Email.Address
            };
        }
    }
}

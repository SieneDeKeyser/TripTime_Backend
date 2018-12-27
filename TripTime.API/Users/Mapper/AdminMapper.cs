using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using TripTime.API.Users.DTO.AdminDTO;
using TripTime.Domain.Users;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.Users.Security;

namespace TripTime.API.Users.Mapper
{
    public class AdminMapper : IMapper<Admin, AdminDTO_Create, AdminDTO_Return>
    {
        private readonly UserAuthenticationService _userService;

        public AdminMapper(UserAuthenticationService userService)
        {
            _userService = userService;
        }



        public AdminDTO_Return DomainToDto(Admin givenDomainObject)
        {
            return new AdminDTO_Return
            {
                Id = givenDomainObject.Id.ToString(),
                FirstName = givenDomainObject.FirstName,
                LastName = givenDomainObject.LastName,
                Email = givenDomainObject.Email.Address
            };

        }

        public Admin DtoToDomain(AdminDTO_Create givenDTO)
        {
            return Admin.CreateNewAdmin(
                givenDTO.FirstName,
                givenDTO.LastName,
                new MailAddress(givenDTO.Email),
                _userService.CreateUserSecurity(givenDTO.Password)
                );
        }


        public List<Admin> DtoListToDomainList(List<AdminDTO_Create> listOfcreateDTOs)
        {
            throw new NotImplementedException();
        }

        public List<AdminDTO_Return> DtoListToDomainList(List<Admin> listOfDomainObjects)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using TripTime.API.Users.DTO.AdminDTO;
using TripTime.API.Users.DTO.UserDTO;
using TripTime.Domain.Users;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.Users.Security;

namespace TripTime.API.Users.Mapper
{
    public class AdminMapper : IMapper<Admin, AdminDTO_Create, AdminDTO_Return>
    {
        private readonly UserAuthenticationService _userService;
        private readonly UserMapper _userMapper;

        public AdminMapper(UserAuthenticationService userService, UserMapper userMapper)
        {
            _userService = userService;
            _userMapper = userMapper;
        }



        public AdminDTO_Return DomainToDto(Admin givenDomainObject)
        {
            return new AdminDTO_Return
            {
                UserDTO = _userMapper.DomainToDto(givenDomainObject)                                    
            };

        }

        public Admin DtoToDomain(AdminDTO_Create givenDTO)
        {
            return Admin.CreateNewAdmin(
                givenDTO.UserDTO.FirstName,
                givenDTO.UserDTO.LastName,
                new MailAddress(givenDTO.UserDTO.LoginDTO.Email),
                _userService.CreateUserSecurity(givenDTO.UserDTO.LoginDTO.Password)
                );
        }


        public List<Admin> DtoListToDomainList(List<AdminDTO_Create> listOfcreateDTOs)
        {
            throw new NotImplementedException();
        }

        public List<AdminDTO_Return> DomainListToDtoList(List<Admin> listOfDomainObjects)
        {
            throw new NotImplementedException();
        }
    }
}

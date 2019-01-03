using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.Mapper;
using TripTime.API.Users.DTO.ClientDTO;
using TripTime.API.Users.DTO.UserDTO;
using TripTime.Domain.Users;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.Users.Security;

namespace TripTime.API.Users.Mapper
{
    public class ClientMapper : IMapper<Client, ClientDTO_Create, ClientDTO_Return>
    {
        private readonly UserAuthenticationService _userService;
        private readonly AddressMapper _addressMapper;
        private readonly UserMapper _userMapper;

        public ClientMapper(UserAuthenticationService userService, AddressMapper addressMapper, UserMapper userMapper)
        {
            _userService = userService;
            _addressMapper = addressMapper;
            _userMapper = userMapper;
        }

        public ClientDTO_Return DomainToDto(Client givenDomainObject)
        {
            return new ClientDTO_Return
            {
                UserDTO = _userMapper.DomainToDto(givenDomainObject),
                AddressDTO = _addressMapper.DomainToDto(givenDomainObject.Address),
                RegistrationDate = givenDomainObject.RegistrationDate,
                Rating = givenDomainObject.Rating
            };
        }

        public Client DtoToDomain(ClientDTO_Create givenDTO)
        {
            return Client.CreateNewClient(
                givenDTO.UserDTO.FirstName,
                givenDTO.UserDTO.LastName,
                new MailAddress(givenDTO.UserDTO.LoginDTO.Email),
                _userService.CreateUserSecurity(givenDTO.UserDTO.LoginDTO.Password),
                _addressMapper.DtoToDomain(givenDTO.AddressDTO),
                givenDTO.Rating
                );
        }


        public List<Client> DtoListToDomainList(List<ClientDTO_Create> listOfcreateDTOs)
        {
            throw new NotImplementedException();
        }

        public List<ClientDTO_Return> DomainListToDtoList(List<Client> listOfDomainObjects)
        {
            throw new NotImplementedException();
        }
    }
}

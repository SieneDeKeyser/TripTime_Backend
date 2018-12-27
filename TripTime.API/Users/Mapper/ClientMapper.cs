using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.Mapper;
using TripTime.API.Users.DTO.ClientDTO;
using TripTime.Domain.Users;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.Users.Security;

namespace TripTime.API.Users.Mapper
{
    public class ClientMapper : IMapper<Client, ClientDTO_Create, ClientDTO_Return>
    {
        private readonly UserAuthenticationService _userService;
        private readonly AddressMapper _addressMapper;

        public ClientMapper(UserAuthenticationService userService, AddressMapper addressMapper)
        {
            _userService = userService;
            _addressMapper = addressMapper;
        }





        public ClientDTO_Return DomainToDto(Client givenDomainObject)
        {
            var userDto = new ClientDTO_Return
            {
                Id = givenDomainObject.Id.ToString(),
                FirstName = givenDomainObject.FirstName,
                LastName = givenDomainObject.LastName,
                Email = givenDomainObject.Email.Address,
                AddressDTO = _addressMapper.DomainToDto(givenDomainObject.Address),
                RegistrationDate = givenDomainObject.RegistrationDate,
                Rating = givenDomainObject.Rating
            };
            return userDto;
        }

        public Client DtoToDomain(ClientDTO_Create givenDTO)
        {
            return Client.CreateNewClient(
                givenDTO.FirstName,
                givenDTO.LastName,
                new MailAddress(givenDTO.Email),
                _userService.CreateUserSecurity(givenDTO.Password),
                _addressMapper.DtoToDomain(givenDTO.AddressDTO),
                givenDTO.Rating
                );
        }


        public List<Client> DtoListToDomainList(List<ClientDTO_Create> listOfcreateDTOs)
        {
            throw new NotImplementedException();
        }

        public List<ClientDTO_Return> DtoListToDomainList(List<Client> listOfDomainObjects)
        {
            throw new NotImplementedException();
        }
    }
}

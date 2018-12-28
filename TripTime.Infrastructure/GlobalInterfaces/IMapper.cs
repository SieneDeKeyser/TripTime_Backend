using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Infrastructure.GlobalInterfaces
{
    public interface IMapper<Domain, CreateDTO, ReturnDTO>
    {
        Domain DtoToDomain(CreateDTO givenDTO);
        List<Domain> DtoListToDomainList(List<CreateDTO> listOfcreateDTOs);
        ReturnDTO DomainToDto(Domain givenDomainObject);
        List<ReturnDTO> DtoListToDomainList(List<Domain> listOfDomainObjects);
    }
}

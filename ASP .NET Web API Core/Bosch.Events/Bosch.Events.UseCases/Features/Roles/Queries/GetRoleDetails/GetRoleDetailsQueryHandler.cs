using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using Bosch.Events.UseCases.Features.Roles.Queries.GetAllRoles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetRoleDetails
{
    public class GetRoleDetailsQueryHandler : IRequestHandler<GetRoleDetailsQuery, RoleDto>
    {
        private readonly ICommonRepository<Role> _commonRepository;
        private readonly IMapper _mapper;
        public GetRoleDetailsQueryHandler(ICommonRepository<Role> commonRepository, IMapper mapper)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
        }
        public async Task<RoleDto> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<RoleDto>(await _commonRepository.GetDetailsAsync(request.RoleId));
        }


    }
}

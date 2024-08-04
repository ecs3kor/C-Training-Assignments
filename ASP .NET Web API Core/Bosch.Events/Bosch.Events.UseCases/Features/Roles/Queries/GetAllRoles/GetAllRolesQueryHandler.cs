using AutoMapper;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosch.Events.Domain.Entities;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleDto>>
    {
        private readonly ICommonRepository<Role> _commonRepository;
        private readonly IMapper _mapper;
        public GetAllRolesQueryHandler(ICommonRepository<Role> commonRepository, IMapper mapper)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
        }
        public async Task<List<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<RoleDto>>(await _commonRepository.GetAllAsync());
        }
    }
}

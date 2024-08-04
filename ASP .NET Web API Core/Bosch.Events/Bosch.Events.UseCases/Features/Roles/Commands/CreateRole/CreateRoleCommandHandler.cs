using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
    {
        private readonly ICommonRepository<Role> _insertRoleRepository;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(ICommonRepository<Role> insertRoleRepository, IMapper mapper)
        {
            _insertRoleRepository = insertRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var new_role = _mapper.Map<Role>(request.Role_Dto);
            return _mapper.Map<int>(await _insertRoleRepository.InsertAsync(new_role));
        }
    }
}

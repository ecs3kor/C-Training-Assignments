using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<int>
    {
        public InsertRoleDto Role_Dto { get; set; }
    }
}

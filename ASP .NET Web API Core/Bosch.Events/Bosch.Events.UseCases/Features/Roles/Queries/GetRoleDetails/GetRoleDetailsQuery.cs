using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetRoleDetails
{
    public class GetRoleDetailsQuery : IRequest<RoleDto>
    {
        public int RoleId { get; set; }
    }
}

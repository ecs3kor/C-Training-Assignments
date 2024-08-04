using Bosch.Events.UseCases.DTOs.RoleDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.Features.Roles.Queries.GetAllRoles
{
    //Query is a requirement
    //Query is reqeusting for list of roles
    public class GetAllRolesQuery : IRequest<List<RoleDto>> { }
    
}

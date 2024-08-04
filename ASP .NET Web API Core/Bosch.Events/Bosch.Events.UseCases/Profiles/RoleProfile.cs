using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.Profiles
{
    internal class RoleProfile :Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<InsertRoleDto, Role>();

        }
    }
}

using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using Bosch.Events.UseCases.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.UseCases.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<InsertUserDto, User>();
            CreateMap<UserDto, User>();

        }
    }
}

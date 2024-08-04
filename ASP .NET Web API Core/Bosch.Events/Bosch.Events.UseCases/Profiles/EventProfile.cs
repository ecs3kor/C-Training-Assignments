using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.DTOs.EventDtos;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Bosch.Events.UseCases.Profiles
{
    internal class EventProfile :Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<InsertEventDto, Event>();

        }
    }
}

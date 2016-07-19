using AutoMapper;
using Dezrez.Rezi.DataContracts.Events;
using Dezrez.Rezi.Domain.Events;

namespace Dezrez.Rezi.Core.Mapping.DataContracts
{
    public class EventMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Event, EventDataContract>().ForMember(dest => dest.Roles,opt => opt.MapFrom(src => src.Roles));
            CreateMap<EventDataContract, Event>().ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles));
        }
    }
}

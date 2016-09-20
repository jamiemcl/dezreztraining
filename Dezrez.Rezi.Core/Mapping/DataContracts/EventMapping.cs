using AutoMapper;
using Dezrez.Rezi.DataContracts.Events.Query;
using Dezrez.Rezi.Domain.Events;

namespace Dezrez.Rezi.Core.Mapping.DataContracts
{
    public class EventMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Event, EventDataContract>().ReverseMap();
        }
    }
}

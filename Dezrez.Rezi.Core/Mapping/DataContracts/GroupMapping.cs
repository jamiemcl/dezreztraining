using AutoMapper;
using Dezrez.Rezi.DataContracts.People.Query;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.Core.Mapping.DataContracts
{
    public class GroupMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Group, GroupDataContract>()
                .ForMember(dest => dest.ListOfPeople, opt => opt.MapFrom(src => src.GroupOfPeople)).ReverseMap();
        }
    }
}

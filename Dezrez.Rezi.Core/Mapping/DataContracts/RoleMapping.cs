using AutoMapper;
using Dezrez.Rezi.DataContracts.Roles;
using Dezrez.Rezi.Domain.Roles;

namespace Dezrez.Rezi.Core.Mapping.DataContracts
{
    public class RoleMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Role, RoleDataContract>()
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Events));
            CreateMap<RoleDataContract, Role>()
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Events));
        }
    }
}

using AutoMapper;
using Dezrez.Rezi.DataContracts.Roles.Query;
using Dezrez.Rezi.Domain.Roles;

namespace Dezrez.Rezi.Core.Mapping.DataContracts
{
    public class RoleMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Role, RoleDataContract>().ReverseMap();
        }
    }
}

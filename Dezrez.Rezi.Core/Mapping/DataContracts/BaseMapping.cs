using AutoMapper;
using Dezrez.Rezi.DataContracts.People;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.Core.Mapping.DataContracts
{
    public class BaseMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Person, PersonDataContract>();
        }
    }
}
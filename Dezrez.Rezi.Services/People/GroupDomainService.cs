using System;
using System.Collections.Generic;
using AutoMapper;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Abstractions.Services;
using Dezrez.Rezi.DataContracts.People;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.Services.People
{
    public class GroupDomainService : BaseDomainService, IGroupDomainService
    {
        private readonly IRepository _repository;

        public GroupDomainService(IRepository repository)
        {
            _repository = repository;
        }

        public IList<GroupDataContract> GetGroups()
        {
            return Mapper.Map<IList<GroupDataContract>>(_repository.FindAll<Group>());
        }

        public void AddGroup(GroupDataContract groupDataContract)
        {
            Group group = Mapper.Map<Group>(groupDataContract);
            _repository.Save(group);
        }
}
}
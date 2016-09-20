using System.Collections.Generic;
using Dezrez.Rezi.DataContracts.People.Query;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.Abstractions.Services
{
    public interface IGroupDomainService
    {
        IList<GroupDataContract> GetGroups();
        void AddGroup(GroupDataContract groupDataContract);
        IList<Group> GetAllGroupsWithEmailAddress(string email);
    }
}
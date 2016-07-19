using System.Collections.Generic;
using Dezrez.Rezi.DataContracts.People;

namespace Dezrez.Rezi.Abstractions.Services
{
    public interface IGroupDomainService
    {
        IList<GroupDataContract> GetGroups();
        void AddGroup(GroupDataContract groupDataContract);
    }
}
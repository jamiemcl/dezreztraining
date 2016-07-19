using System.Collections.Generic;
using Dezrez.Rezi.DataContracts.Events;
using Dezrez.Rezi.DataContracts.Roles;

namespace Dezrez.Rezi.Abstractions.Services
{
    public interface IRoleDomainService
    {
        IList<RoleDataContract> GetRoles();
        void AddRole(RoleDataContract roleContract);
    }
}

using System.Collections.Generic;
using Dezrez.Rezi.DataContracts.Roles.Query;

namespace Dezrez.Rezi.Abstractions.Services
{
    public interface IRoleDomainService
    {
        IList<RoleDataContract> GetRoles();
        void AddRole(RoleDataContract roleContract);
    }
}

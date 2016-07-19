using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Abstractions.Services;
using Dezrez.Rezi.DataContracts.Roles;
using Dezrez.Rezi.Domain.Roles;

namespace Dezrez.Rezi.Services.Roles
{
    class RoleDomainService : BaseDomainService, IRoleDomainService 
    {
        private readonly IRepository _repository;

        public RoleDomainService(IRepository repository)
        {
            _repository = repository;
        }

        public IList<RoleDataContract> GetRoles()
        {
            var roles = _repository.FindAll<Role>();
            return Mapper.Map<IList<RoleDataContract>>(roles);
        }

        public void AddRole(RoleDataContract roleContract)
        {
            var role = Mapper.Map<Role>(roleContract);
            _repository.Save(role);
        }
    }
}

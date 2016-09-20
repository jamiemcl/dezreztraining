using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Abstractions.Services;
using Dezrez.Rezi.DataContracts.Events.Query;
using Dezrez.Rezi.DataContracts.Roles.Query;
using Dezrez.Rezi.Domain.Events;
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
            var events = new List<Event>();

            foreach (EventDataContract ev in roleContract.Events)
            {
                events.Add(new Event
                {
                    Id = ev.Id,
                    CreatedDate = ev.CreatedDate,
                    Deleted = ev.Deleted,
                    Roles = Mapper.Map<IList<Role>>(ev.Roles)
                });
            }

            Role role = new Role()
            {
                CreatedDate = roleContract.CreatedDate,
                Deleted = roleContract.Deleted,
                Events = events
            };

            _repository.Save(role);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain.Events;
using Dezrez.Rezi.Domain.Roles;
using Dezrez.Rezi.Repository.Configurations.Conventions;
using NHibernate.Mapping.ByCode;

namespace Dezrez.Rezi.Repository.Configurations.Mappings
{
    public class RoleMappings
    {
        public static void Map(ConventionModelMapper mapper)
        {
            mapper.ManyToMany<Role, Event>(e => e.Events, e => e.Roles);
        }
    }
}

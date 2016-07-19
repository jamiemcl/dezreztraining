using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain.Events;
using Dezrez.Rezi.Domain.Roles;
using Dezrez.Rezi.Repository.Configurations.Conventions;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace Dezrez.Rezi.Repository.Configurations.Mappings
{
    public class EventMapping
    {
        public static void Map(ConventionModelMapper mapper)
        {
            mapper.ManyToMany<Event, Role>(e => e.Roles, e => e.Events);
        }
    }
}

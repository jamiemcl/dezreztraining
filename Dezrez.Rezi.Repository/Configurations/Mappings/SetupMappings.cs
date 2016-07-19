using System.Linq;
using Dezrez.Rezi.Domain;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace Dezrez.Rezi.Repository.Configurations.Mappings
{
    public class SetupMappings
    {
        public static HbmMapping Get(ConventionModelMapper mapper)
        {
            mapper.IsEntity((type, declared) =>
                typeof(BaseEntity).IsAssignableFrom(type) &&
                typeof(BaseEntity) != type &&
                !type.IsInterface);
            mapper.IsRootEntity((type, declared) => type.BaseType == typeof(BaseEntity));

            mapper.Class<BaseEntity>(p => p.Id(c => c.Id, m => m.Generator(new IdentityGeneratorDef())));

            var allEntities = typeof(BaseEntity).Assembly.GetTypes().ToList();

            // Do any other custom mapping changes here if needed.
            // I.E. BaseMapping.Create(mapper);


            var mapping = mapper.CompileMappingFor(allEntities);
            return mapping;
        }
    } 
}
using System.Collections.Generic;
using System.Linq;
using Dezrez.Rezi.Domain;
using NHibernate;
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

            Map(mapper, new IdentityGeneratorDef(), null);
            // Do any other custom mapping changes here if needed.
            // I.E. BaseMapping.Create(mapper);


            var mapping = mapper.CompileMappingFor(allEntities);
            return mapping;
        }

        public static void Map(ConventionModelMapper mapper, IGeneratorDef generatorDef, object generatorParams)
        {
            MapIds(mapper, generatorDef);

            MapSqlKeywords(mapper);

            MapCollections(mapper);

            MapMaps(mapper);

            MapSubclasses(mapper);

            MapElements(mapper);
        }

        private static void MapIds(ConventionModelMapper mapper, IGeneratorDef generatorDef)
        {

            mapper.BeforeMapClass += (i, p, m) =>
            {
                m.Cache(c => c.Usage(CacheUsage.ReadWrite));
                if (p.GetMember("Id").Any())
                {
                    m.Id(p.GetMember("Id").Single(), idm => idm.Generator(generatorDef));
                }
            };
        }

        private static void MapSqlKeywords(ConventionModelMapper mapper)
        {

            IList<string> sqlKeywords = new List<string> { "Order", "Option", "Group", "Trigger", "Identity", "Key" };

            mapper.BeforeMapClass += (i, p, m) =>
            {
                if (sqlKeywords.Any(self => self == p.Name))
                {
                    m.Table("[" + p.Name + "]");
                }
            };

            mapper.BeforeMapProperty += (i, p, m) =>
            {
                if (sqlKeywords.Any(self => self == p.LocalMember.Name))
                {
                    m.Column("[" + p.LocalMember.Name + "]");
                }
            };
        }

        private static void MapCollections(ConventionModelMapper mapper)
        {
            mapper.BeforeMapManyToOne += (i, p, m) =>
            {
                if (p.LocalMember.DeclaringType != null && p.LocalMember.DeclaringType.Name == "Appointment" &&
                    p.LocalMember.Name == "MeetingPoint")
                {
                    m.Column("MeetingPointId");
                }
                else if (p.LocalMember.DeclaringType != null && p.LocalMember.DeclaringType.Name == "ViewingFeedback" &&
                p.LocalMember.Name == "VendorCommunication")
                {
                    m.Column("VendorCommunicationId");
                }
                else
                {
                    m.Column(c => c.Name(p.LocalMember.GetPropertyOrFieldType().Name + "Id"));
                }
            };


            mapper.BeforeMapClass += (i, p, m) =>
            {
                m.DynamicInsert(true);
                m.DynamicUpdate(true);
            };
            mapper.BeforeMapManyToOne += (i, p, m) => m.Cascade(Cascade.Persist);

            mapper.BeforeMapList += (i, p, m) => m.Key(km => km.Column(c => c.Name(p.GetContainerEntity(i).Name + "Id")));
            mapper.BeforeMapList += (i, p, m) => m.Cascade(Cascade.Persist);

            mapper.BeforeMapSet += (i, p, m) => m.Key(km => km.Column(c => c.Name(p.GetContainerEntity(i).Name + "Id")));
            mapper.BeforeMapSet += (i, p, m) => m.Cascade(Cascade.Persist);

            mapper.BeforeMapBag += (i, p, m) => m.Key(km => km.Column(c => c.Name(p.GetContainerEntity(i).Name + "Id")));
            mapper.BeforeMapBag += (i, p, m) => m.Cascade(Cascade.Persist);
        }

        private static void MapSubclasses(ConventionModelMapper mapper)
        {
            //Map the Ids of joined subclasses
            mapper.BeforeMapJoinedSubclass += (i, p, m) =>
            {
                m.Key(k => k.Column(p.BaseType.Name + "Id"));
            };
        }

        private static void MapMaps(ConventionModelMapper mapper)
        {
            //Map the table name and Id for Maps
            mapper.BeforeMapMap += (i, p, m) =>
            {
                m.Table(p.LocalMember.DeclaringType.Name + "_" + p.LocalMember.Name);
                m.Key(k => k.Column(p.LocalMember.DeclaringType.Name + "Id"));
            };

            //Map Key column of m
            mapper.BeforeMapMapKey += (i, p, m) => m.Column("[Key]");
        }

        private static void MapElements(ConventionModelMapper mapper)
        {
            //Map value column of element (contained in above m)
            mapper.BeforeMapElement += (i, p, m) =>
            {
                m.Column("Value");
                m.NotNullable(true);

                m.Type(NHibernateUtil.String);
            };
        }
    }
}
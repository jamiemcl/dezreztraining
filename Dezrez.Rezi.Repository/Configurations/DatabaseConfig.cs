using System;
using System.Collections.Generic;
using System.Linq;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Repository.Configurations.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Dezrez.Rezi.Repository.Configurations
{
    public class DatabaseConfig : IDatabaseConfig
    {
        public ISessionFactory SessionFactory
        {
            get { return GetSessionFactory(); }
        }

        private Configuration _configuration;

        private ISessionFactory GetSessionFactory()
        {
            return BuildConfiguration().BuildSessionFactory();
        }

        private Configuration BuildConfiguration()
        {
            if (_configuration == null)
            {
                var configuration = new Configuration();

                var mapper = new ConventionModelMapper();
                HbmMapping mapping = SetupMappings.Get(mapper);
                configuration.AddMapping(mapping);

                _configuration = configuration;

            }
            return _configuration;
        }

        ISessionFactory IDatabaseConfig.SessionFactory()
        {
            return SessionFactory;
        }

        public void CreateDbSchema()
        {
            Configuration config = BuildConfiguration();
            new SchemaExport(config).Create(false, true);
        }

        /// <summary>
        /// Only use if simple updates to schema
        /// </summary>
        public void UpdateDbSchema()
        {
            Configuration config = BuildConfiguration();
            new SchemaUpdate(config).Execute(false, true);
        }
    }
}
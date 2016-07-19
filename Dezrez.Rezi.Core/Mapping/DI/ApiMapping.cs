using System.Reflection;
using Autofac;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Repository;
using Dezrez.Rezi.Repository.Configurations;
using Dezrez.Rezi.Services;
using NHibernate;

namespace Dezrez.Rezi.Core.Mapping.DI
{
    public class ApiMapping
    {
        public static void Register(ContainerBuilder builder)
        {
            RepositoryMappings(builder);
            ServiceMappings(builder);
        }

        public static void RepositoryMappings(ContainerBuilder builder)
        {
            builder.RegisterType<BasicInterceptor>().As<IInterceptor>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof (Repository.Repository)))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<DatabaseConfig>().As<IDatabaseConfig>().InstancePerLifetimeScope();
        }

        public static void ServiceMappings(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BaseDomainService)))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }
}
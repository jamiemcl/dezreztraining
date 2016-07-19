using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Core.Mapping.DataContracts;
using Dezrez.Rezi.Core.Mapping.DI;
using Dezrez.Rezi.Training.Controllers;
using Dezrez.Rezi.Training.Filters;

namespace Dezrez.Rezi.Training
{
    public static class AppConfig
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            builder.RegisterType<UnhandledExceptionFilter>()
               .AsWebApiExceptionFilterFor<BaseApiController>()
               .InstancePerRequest();

            builder.RegisterType<CompleteUnitOfWorkAttribute>()
               .AsWebApiActionFilterFor<BaseApiController>()
               .InstancePerRequest();

            ApiMapping.Register(builder);

            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AutofacWebApiDependencyResolver resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            Mapper.Initialize(MappingConfiguration.Configure);
            Mapper.AssertConfigurationIsValid();

            // NB. Comment out if you want to prevent db schema updates.
            var dbConfig = container.Resolve<IDatabaseConfig>();
            dbConfig.UpdateDbSchema();
        }
    }
}
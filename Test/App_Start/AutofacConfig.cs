using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Test.Interfaces.Services;
using Test.Repositories;
using Test.Services;

namespace Test.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<ProductService>().As<IProductService>();

            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());


            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(type => type.FullName.StartsWith("Test.Services") ||
                      type.FullName.StartsWith("Test.Repositories"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();


            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
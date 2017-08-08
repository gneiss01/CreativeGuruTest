using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using TestWeb.Controllers;
using TestWeb.Data.Model;
using TestWeb.Data.Repository;

namespace TestWeb.App_Start
{
    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
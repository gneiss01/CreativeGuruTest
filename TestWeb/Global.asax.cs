using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestWeb.App_Start;

namespace TestWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IoCConfig.RegisterDependencies();
        }
    }
}

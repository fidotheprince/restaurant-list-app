using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestData.Web.App;

namespace TestData.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //register Container
            ContainerConfig.RegisterContainer();
        }
    }
}

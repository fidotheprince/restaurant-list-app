using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using TestData.Web.Services;

namespace TestData.Web.App
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<DbData>().InstancePerRequest();
            //grab data from sql server per request
            //as opposed to single instance of initial request
            //app to server connection done thru connection string
            builder.RegisterType<FidoFoodsDbContext>().InstancePerRequest();

            var container = builder.Build();

            //user this container as dependency resolver for app 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
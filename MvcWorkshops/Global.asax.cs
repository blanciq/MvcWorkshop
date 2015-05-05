using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MvcWorkshops.Repository;

namespace MvcWorkshops
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<NewsRepository>()
                .As<IRepository<News>>()
                .WithParameter("connectionString", 
                    ConfigurationManager.ConnectionStrings["Db"].ConnectionString);

            builder.RegisterType<UserRepository>()
                .As<IRepository<User>>()
                .WithParameter("connectionString", 
                    ConfigurationManager.ConnectionStrings["Db"].ConnectionString);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

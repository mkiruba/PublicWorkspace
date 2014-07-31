
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SimpleUserRegistration.Business;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;


namespace SimpleUserRegistration.UI.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            
            //Workaround for WebAPI
            IContainer container = RegisterServices(builder);
            config.DependencyResolver = new AutofacWebAPIDependencyResolver(container);
            
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebAPIDependencyResolver(container);
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(
                typeof(MvcApplication).Assembly
            ).PropertiesAutowired();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();

            return
                builder.Build();
        }
    }
}
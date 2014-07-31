using SimpleUserRegistration.UI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;

namespace SimpleUserRegistration.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //IocConfig.RegisterDependencies(config);
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

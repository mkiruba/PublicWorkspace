using Autofac;
using SimpleUserRegistration.Business;
using SimpleUserRegistration.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUserRegistration.Core
{
    public class Bootstrap
    {
        public static IContainer Components()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            return builder.Build();
        }
    }
}

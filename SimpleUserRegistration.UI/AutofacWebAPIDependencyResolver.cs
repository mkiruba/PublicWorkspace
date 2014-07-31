using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;


namespace SimpleUserRegistration.UI
{
    public class AutofacWebAPIDependencyResolver : IDependencyResolver
    {

        private readonly IContainer _container;

        public AutofacWebAPIDependencyResolver(IContainer container)
        {

            _container = container;
        }

        public object GetService(Type serviceType)
        {

            return _container.IsRegistered(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {

            Type enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            object instance = _container.Resolve(enumerableServiceType);
            return ((IEnumerable)instance).Cast<object>();
        }


        public IDependencyScope BeginScope()
        {
            
            return new AutofacWebAPIDependencyResolver(_container);
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
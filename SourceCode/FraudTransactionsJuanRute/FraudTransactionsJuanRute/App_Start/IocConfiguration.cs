using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace FraudTransactionsJuanRute.App_Start
{
    public static class IOCConfiguration
    {
        public static void ConfigureIocUnityContainer() {
            IUnityContainer container = new UnityContainer();
            registerServices(container);
            DependencyResolver.SetResolver(new ResolverUnit(container));
        }

        private static void registerServices(IUnityContainer container)
        {
            container.RegisterType<IFacade, Facade>();
        }
    }

    internal class ResolverUnit : IDependencyResolver
    {
        private IUnityContainer container;

        public ResolverUnit(IUnityContainer _container)
        {
            this.container = _container;
        }

        public object GetService(Type serviceType)
        {
            try
            {

                return container.Resolve(serviceType);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (Exception)
            {

                return new List<Object>();
            }
        }
    }
}
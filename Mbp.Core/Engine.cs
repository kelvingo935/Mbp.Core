#region using

using System;
using System.Collections.Generic;
using System.Linq;
using DryIoc;
using Mbp.Core.Interfaces;

#endregion

namespace Mbp.Core
{
    public static class Engine
    {
        #region Static Fields and Properties

        public static string Version => "0.0.1";

        public static IPlatform Platform => Resolve<IPlatform>();

        public static ICurrent Current => Resolve<ICurrent>();

        public static IContainer Container { get; }

        #endregion

        #region Static Constructors

        static Engine()
        {
            Container = new Container();
        }

        #endregion

        #region Methods

        public static void Start()
        {
            Container.ScanAssemblies<IModule>();

            // Configure module services
            var modules = ResolveMany<IModule>();
            foreach (var module in modules)
            {
                module.ConfigureServices(Container);
            }
        }

        public static string Diagnostics()
        {
            return string.Join("\r\n", Container.GetServiceRegistrations()
                .Select(
                    x =>
                        $"[{x.OptionalServiceKey}]\r\n{x.ServiceType.FullName}\r\n{x.Factory.ImplementationType?.FullName}"));
        }

        public static object MustResolve(Type serviceType,
            string serviceKey)
        {
            return Container.Resolve(serviceType, serviceKey);
        }

        public static T MustResolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static T MustResolve<T>(string serviceKey)
        {
            return Container.Resolve<T>(serviceKey);
        }

        public static object Resolve(Type serviceType)
        {
            return Container.Resolve(serviceType, IfUnresolved.ReturnDefault);
        }

        public static object Resolve(Type serviceType,
            string serviceKey)
        {
            return Container.Resolve(serviceType, serviceKey, IfUnresolved.ReturnDefault);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>(IfUnresolved.ReturnDefault);
        }

        public static T Resolve<T>(string serviceKey)
        {
            return Container.Resolve<T>(serviceKey, IfUnresolved.ReturnDefault);
        }

        public static IEnumerable<object> ResolveMany(Type serviceType)
        {
            return Container.ResolveMany(serviceType);
        }

        public static IEnumerable<object> ResolveMany(Type serviceType,
            string serviceKey)
        {
            return Container.ResolveMany(serviceType, serviceKey: serviceKey);
        }

        public static IEnumerable<T> ResolveMany<T>()
        {
            return Container.ResolveMany<T>();
        }

        public static IEnumerable<T> ResolveMany<T>(string serviceKey)
        {
            return Container.ResolveMany<T>(serviceKey: serviceKey);
        }

        #endregion
    }
}

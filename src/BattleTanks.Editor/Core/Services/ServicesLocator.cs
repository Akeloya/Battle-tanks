using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;

namespace BattleTanks.Editor.Core.Services
{
    public static class ServicesLocator
    {
        private static IServiceProvider? provider;
        private static readonly ServiceCollection services = new ();
        public static void RegisterServices(Action<IServiceCollection> act)
        {
            act(services);
            provider = services.BuildServiceProvider();
        }

        public static T? Get<T>()
        {
            if(provider == null)
                throw new NullReferenceException();
            return provider.GetService<T>();
        }

        public static IEnumerable<T?> GetAll<T>()
        {
            if(provider == null)
                throw new NullReferenceException();
            return provider.GetServices<T>();
        }
    }
}

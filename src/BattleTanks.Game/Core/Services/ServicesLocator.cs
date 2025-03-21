﻿using Avalonia.Controls;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;

namespace BattleTanks.Game.Core.Services
{
    public static class ServicesLocator
    {
#pragma warning disable CS8618
        private static IServiceProvider provider;
#pragma warning restore CS8618
        private static readonly ServiceCollection services = new ();
        public static void RegisterServices(Action<IServiceCollection> act)
        {
            act(services);
            provider = services.BuildServiceProvider(new ServiceProviderOptions()
            {
                ValidateOnBuild = true
            });
        }
        public static IServiceProvider Provider => provider;
        public static T Get<T>()
        {
            return provider.GetService<T>() ?? throw new ArgumentOutOfRangeException();
        }

        public static IEnumerable<T> GetAll<T>()
        {
            return provider.GetServices<T>();
        }

        internal static Control? Get<T>(Type type)
        {
            return provider.GetService(type) as Control;
        }
    }
}

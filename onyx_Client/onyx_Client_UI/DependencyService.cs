using Microsoft.Extensions.DependencyInjection;
using onyx_Client_UI.Services;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.State.Navigators;
using System;

namespace onyx_Client_UI
{
    public static class DependencyService
    {
        private static IServiceProvider _services;

        private static IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<ICatalogInteraction, CatalogInteraction>();

            return services.BuildServiceProvider();
        }

        public static void Initialize()
        {
            if (_services == null)
                _services = CreateServiceProvider();
        }

        public static T Get<T>()
        {
            return _services.GetRequiredService<T>();
        }
    }
}

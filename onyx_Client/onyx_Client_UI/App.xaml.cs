using Microsoft.Extensions.DependencyInjection;
using Onyx.Config;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.State.Navigators;
using onyx_Client_UI.ViewModels;
using onyx_Client_UI.ViewModels.HomeDetails;
using onyx_Client_UI.Views;
using System;
using System.Windows;

namespace onyx_Client_UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Config Config;
        public static HttpBroker.Client HttpClient;
        public static HttpBroker.Models.AuthorizeData AuthorizeData;
        public App()
        {
            Config = Config.getConfig();
            HttpClient = HttpBroker.Client.getClient();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            var _navigator = serviceProvider.GetRequiredService<INavigator>();

            Window window = new MainWindow();
            window.DataContext = new MainViewModel(_navigator);
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<INavigator, Navigator>();

            services.AddScoped<IAuthenticator, Authenticator>();

            return services.BuildServiceProvider();
        }
    }
}

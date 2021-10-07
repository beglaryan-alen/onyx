using Onyx.Config;
using onyx_Client_UI.ViewModels;
using onyx_Client_UI.Views;
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
            AuthorizeData = new HttpBroker.Models.AuthorizeData();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DependencyService.Initialize();

            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }

        
    }
}

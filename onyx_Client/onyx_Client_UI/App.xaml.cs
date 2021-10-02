using Onyx.Config;
using onyx_Client_UI.Stores;
using onyx_Client_UI.ViewModel;
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
        public App()
        {
            Config = Config.getConfig();
            HttpClient = HttpBroker.Client.getClient();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

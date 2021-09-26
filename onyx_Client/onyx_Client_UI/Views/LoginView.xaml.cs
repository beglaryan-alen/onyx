using onyx_Client_UI.ViewModel;
using System.Windows;

namespace onyx_Client_UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;

        }
    }
}

using onyx_Client_UI.Commands;
using onyx_Client_UI.Stores;
using System.Windows.Input;

namespace onyx_Client_UI.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand LogoutCommand { get; set; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            LogoutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
    }
}

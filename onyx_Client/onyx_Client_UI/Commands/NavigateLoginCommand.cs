using onyx_Client_UI.Stores;
using onyx_Client_UI.ViewModel;

namespace onyx_Client_UI.Commands
{
    public class NavigateLoginCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);
        }
        public NavigateLoginCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}

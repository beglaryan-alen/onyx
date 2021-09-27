using onyx_Client_UI.Stores;
using onyx_Client_UI.ViewModel;

namespace onyx_Client_UI.Commands
{
    public class NavigateHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }
        public NavigateHomeCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}

using onyx_Client_UI.Stores;
using onyx_Client_UI.ViewModel;
using System;

namespace onyx_Client_UI.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore  = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_createViewModel().GetType() == typeof(LoginViewModel))
            {
            }
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}

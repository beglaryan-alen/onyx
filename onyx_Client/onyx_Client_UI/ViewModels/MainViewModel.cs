using onyx_Client_UI.State.Navigators;
using onyx_Client_UI.ViewModel;

namespace onyx_Client_UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        public MainViewModel()
        {
            _navigator = DependencyService.Get<INavigator>();
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigator.GoToLogin();
        }

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

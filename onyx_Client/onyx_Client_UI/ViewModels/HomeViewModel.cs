using MvvmHelpers.Commands;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.State.Navigators;
using onyx_Client_UI.ViewModels;
using System;
using System.Windows.Input;

namespace onyx_Client_UI.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly ViewModelBase _gamesViewModel;
        private readonly ViewModelBase _softViewModel;
        private readonly ViewModelBase _promocodeViewModel;
        public HomeViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _gamesViewModel = new GamesViewModel();
            _softViewModel = new SoftViewModel();
            _promocodeViewModel = new PromocodeViewModel();
            CurrentViewModel = _gamesViewModel;
        }

        public ICommand LogoutCommand { get; set; }
        public ICommand MenuCommand => new Command<string>(OnMenuCommand);
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged(nameof(CurrentViewModel));
                }
            }
        }

        private void OnMenuCommand(string pageName)
        {
            if (pageName == "Games")
                CurrentViewModel = _gamesViewModel;
            else if (pageName == "Soft")
                CurrentViewModel = _softViewModel;
            else if (pageName == "Promocode")
                CurrentViewModel = _promocodeViewModel;
        }
    }
}

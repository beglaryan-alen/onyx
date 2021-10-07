using MvvmHelpers.Commands;
using onyx_Client_UI.Services;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.State.Navigators;
using onyx_Client_UI.ViewModels.HomeDetails;
using System;
using System.Windows.Input;

namespace onyx_Client_UI.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        #region Private Properties

        private readonly ViewModelBase _gamesViewModel;
        private readonly ViewModelBase _softViewModel;
        private readonly ViewModelBase _promocodeViewModel;

        #endregion

        #region Constructor

        public HomeViewModel()
        {
            _gamesViewModel = new GamesViewModel();
            _softViewModel = new SoftViewModel();
            _promocodeViewModel = new PromocodeViewModel();
            HomeDetailsView = new HomeDetailsViewModel();
            CurrentViewModel = _gamesViewModel;
        }
        #endregion

        #region Public Properties

        public ICommand LogoutCommand => new Command(OnLogoutCommand);

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


        private ViewModelBase _homeDetailsView;
        public ViewModelBase HomeDetailsView
        {
            get => _homeDetailsView;
            set
            {
                if (_homeDetailsView != value)
                {
                    _homeDetailsView = value;
                    OnPropertyChanged(nameof(HomeDetailsView));
                }
            }
        }

        #endregion

        #region Private Helpers

        private void OnMenuCommand(string pageName)
        {
            if (pageName == "Games")
                CurrentViewModel = _gamesViewModel;
            else if (pageName == "Soft")
                CurrentViewModel = _softViewModel;
            else if (pageName == "Promocode")
                CurrentViewModel = _promocodeViewModel;
        }

        private void OnLogoutCommand()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

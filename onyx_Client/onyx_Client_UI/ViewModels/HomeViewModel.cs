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
        #region Private ViewModels

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
            HomeDetailsViewModel = new HomeDetailsViewModel();
            ProfileViewModel = new ProfileViewModel();
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


        private HomeDetailsViewModel _homeDetailsViewModel;
        public HomeDetailsViewModel HomeDetailsViewModel
        {
            get => _homeDetailsViewModel;
            set => SetPropertyChanged(nameof(HomeDetailsViewModel), ref _homeDetailsViewModel, value);
        }

        private ProfileViewModel _profileViewModel;
        public ProfileViewModel ProfileViewModel
        {
            get => _profileViewModel;
            set => SetPropertyChanged(nameof(ProfileViewModel), ref _profileViewModel, value);
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

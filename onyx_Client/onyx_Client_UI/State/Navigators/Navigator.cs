using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.ViewModel;
using System;

namespace onyx_Client_UI.State.Navigators
{
    public class Navigator : INavigator
    {
        private readonly HomeViewModel homeView;
        private readonly LoginViewModel loginView;
        public Navigator(IAuthenticator authenticator)
        {
            loginView = new LoginViewModel(this, authenticator);
            homeView = new HomeViewModel(this);
        }

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    CurrentViewModelChanged?.Invoke();
                }
            }
        }

        public event Action CurrentViewModelChanged;

        public void GoToHome()
        {
            CurrentViewModel = homeView;
        }

        public void GoToLogin()
        {
            CurrentViewModel = loginView;
        }

    }
}

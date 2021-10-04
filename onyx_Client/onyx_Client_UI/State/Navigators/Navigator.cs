using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.ViewModel;
using System;

namespace onyx_Client_UI.State.Navigators
{
    public class Navigator : INavigator
    {
        private readonly IAuthenticator _authenticator;
        public Navigator(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
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
            CurrentViewModel = new HomeViewModel(this, _authenticator);
        }

        public void GoToLogin()
        {
            CurrentViewModel = new LoginViewModel(this, _authenticator);
        }

    }
}

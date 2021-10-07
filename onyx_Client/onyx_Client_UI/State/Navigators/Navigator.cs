using onyx_Client_UI.Services;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.ViewModel;
using System;

namespace onyx_Client_UI.State.Navigators
{
    public class Navigator : INavigator
    {
        private readonly IAuthenticator _authenticator;

        private readonly ICatalogInteraction _catalogInteraction;
        public Navigator(IAuthenticator authenticator, 
                         ICatalogInteraction catalogInteraction)
        {
            _catalogInteraction = catalogInteraction;
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
            CurrentViewModel = new HomeViewModel(this, _authenticator, _catalogInteraction);
        }

        public void GoToLogin()
        {
            CurrentViewModel = new LoginViewModel(this, _authenticator);
        }

    }
}

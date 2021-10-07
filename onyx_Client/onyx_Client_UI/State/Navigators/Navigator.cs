using onyx_Client_UI.Services;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.ViewModel;
using System;

namespace onyx_Client_UI.State.Navigators
{
    public class Navigator : INavigator
    {
        private readonly IAuthenticator _authenticator;
<<<<<<< HEAD
        private readonly ICatalogInteraction _catalogInteraction;
        public Navigator(IAuthenticator authenticator, 
                         ICatalogInteraction catalogInteraction)
=======
        private readonly Services.ICatalogInteraction _catalog;
        public Navigator(IAuthenticator authenticator,Services.ICatalogInteraction catalog)
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf
        {
            _catalogInteraction = catalogInteraction;
            _authenticator = authenticator;
            _catalog = catalog;
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
<<<<<<< HEAD
            CurrentViewModel = new HomeViewModel(this, _authenticator, _catalogInteraction);
=======
            CurrentViewModel = new HomeViewModel(this, _authenticator,_catalog);
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf
        }

        public void GoToLogin()
        {
            CurrentViewModel = new LoginViewModel(this, _authenticator);
        }

    }
}

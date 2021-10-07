using onyx_Client_UI.ViewModel;
using System;

namespace onyx_Client_UI.State.Navigators
{
    class Navigator : INavigator
    {

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
            CurrentViewModel = new HomeViewModel();
        }

        public void GoToLogin()
        {
            CurrentViewModel = new LoginViewModel();
        }

    }
}

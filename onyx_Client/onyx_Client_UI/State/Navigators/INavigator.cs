using onyx_Client_UI.ViewModel;
using System;

namespace onyx_Client_UI.State.Navigators
{
    public interface INavigator
    {
        event Action CurrentViewModelChanged;
        ViewModelBase CurrentViewModel { get; set; }

        void GoToHome();

        void GoToLogin();
    }
}

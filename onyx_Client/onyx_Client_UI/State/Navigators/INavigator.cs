using onyx_Client_UI.ViewModel;

namespace onyx_Client_UI.State.Navigators
{
    public interface INavigator
    {
        void UpdateView<T>(T model) where T : ViewModelBase;

        void GoToHome();

        void GoToLogin();
    }
}

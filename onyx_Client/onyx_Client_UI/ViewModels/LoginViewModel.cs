using MvvmHelpers.Commands;
using onyx_Client_UI.State.Authenticators;
using onyx_Client_UI.State.Navigators;
using System.Threading.Tasks;
using System.Windows.Input;

namespace onyx_Client_UI.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Private Properties

        private readonly IAuthenticator _authenticator;

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            _authenticator = DependencyService.Get<IAuthenticator>();
        }

        #endregion

        #region Public Properties

        public ViewModelBase CurrentViewModel { get; }

        public ICommand LoginCommand => new AsyncCommand(OnLoginCommand);
        public ICommand Register => new AsyncCommand(OnRegisterCommand);

        private string _id;
        public string Id
        {
            get => _id;
            set => SetPropertyChanged(nameof(Id), ref _id, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetPropertyChanged(nameof(Password), ref _password, value);
        }

        #endregion

        #region Private Helpers

        private async Task OnLoginCommand()
        {
            try
            {
                var response = await _authenticator.LoginAsync(Id, Password);
            }
            catch
            {
                //stay at login page
            }
        }

        private async Task OnRegisterCommand()
        {
        }

        #endregion
    }
}

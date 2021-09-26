using MvvmHelpers.Commands;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace onyx_Client_UI.ViewModel
{
    public class LoginViewModel : WindowedBaseVM
    {
        #region Public Properties

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
        }

        private async Task OnRegisterCommand()
        {
        }

        #endregion
    }
}

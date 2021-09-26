using HttpBroker.Models;
using onyx_Client_UI.Models;
using onyx_Client_UI.Models.Auth;
using System;
using System.Threading.Tasks;

namespace onyx_Client_UI.Services
{
    public class Authenticator : IAuthenticator
    {
        public User CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        /// <summary>
        /// Register new user.
        /// </summary>
        /// <param name="User">User to register.</param>
        /// <returns>Register result</returns>
        public Task<Response> Register(User user)
        {
            return Task.Run(() =>HttpBroker.Client.Post<User, Response>(user, $"{App.config.BaseUrl}/authorize/register"));
        }

        /// <summary>
        /// Login into system.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>If user exists.</returns>
        public async Task<Response> Login(string username, string password)
        {
            var response = HttpBroker.Client.Post<LoginRequest, DataResponse<LoginResponse>>(new LoginRequest() { Login = username, Password = password },$"{App.config.BaseUrl}/authorize/login");
            if (response.IsOk)
                CurrentUser = response.Data.User;
            return response;
        }

        public Task Logout()
        {
            throw new System.NotImplementedException();
        }

    }
}

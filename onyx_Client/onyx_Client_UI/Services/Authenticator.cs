using HttpBroker.Models;
using onyx_Client_UI.Models;
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
        public Task<Response> Register(User User)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Login into system.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>If can logged in.</returns>
        public async Task<bool> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task Logout()
        {
            throw new System.NotImplementedException();
        }

    }
}

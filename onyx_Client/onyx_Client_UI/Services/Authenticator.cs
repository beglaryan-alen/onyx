using HttpBroker.Models;
using onyx_Client_UI.Models;
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
            //TODO: Realize method correctly.
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Login into system.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>If user exists.</returns>
        public async Task<bool> Login(string username, string password)
        {
            //TODO: Realize method correctly.
            var user = new User()
            {
                Email = username,
                Password = password,
                Id = 123456,
                DateOfBirth = DateTime.Now,
                Gender = Gender.Man,
                IdentificationNumber = "Id223322",
                IDNumber = "IDD232323",
                Name = "Имя",
                Patronymic = "Отчество",
                SurName = "Фамилия",
                PhoneNumber = "+37477221409",
            };
            CurrentUser = user;
            return true;
        }

        public Task Logout()
        {
            throw new System.NotImplementedException();
        }

    }
}

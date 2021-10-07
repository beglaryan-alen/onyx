using HttpBroker.Models;
using onyx_Client_UI.Models;
using onyx_Client_UI.State.Navigators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoginRequest = HttpBroker.Models.LoginRequest;

namespace onyx_Client_UI.State.Authenticators
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
        public Task<Response> RegisterAsync(User user)
        {
            return Task.Run(() => App.HttpClient.Post<User, Response>(user, $"{App.Config.BaseUrl}/authorize/register"));
        }

        /// <summary>
        /// Login into system.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>If user exists.</returns>
        public async Task<Response> LoginAsync(string ID, string password)
        {
            DataResponse<HttpBroker.Models.LoginResponse> response;
            try
            {
                response= App.HttpClient.PostAuth(new LoginRequest() {Login=ID,Password=password },$"{App.Config.AuthUrl}/connect/token");
                if (response.IsOk)
                    App.AuthorizeData.Token = response.Data.Access_token;

                //Пока остается заглушка, до тех пор, пока историю посещений, баланс итд не будем получать от сервера
                CurrentUser = new User()
                {
                    Id = 24455,
                    DateOfBirth = DateTime.Now,
                    Email = "alen@alen.com",
                    Gender = Gender.Man,
                    IdentificationNumber = "3434NN4343",
                    IDNumber = "123456",
                    Name = "Alen",
                    Password = password,
                    Patronymic = "Beglaryan",
                    PhoneNumber = "+7123123123",
                    SurName = "Surname",
                    Visits = new List<DateTime>()
                    {
                        new DateTime(2021, 04, 28),
                        new DateTime(2021, 04, 30),
                        new DateTime(2021, 03, 31),
                        new DateTime(2000, 04, 20),
                        new DateTime(2020, 04, 22),
                    },
                    Balance = 23450,
                    Cashback = 200,
                    Bonus = 400,
                };



                return response;
            }
            //try
            //{
            //    var response = App.HttpClient.Post<LoginRequest, DataResponse<LoginResponse>>(new LoginRequest() { Login = username, Password = password }, $"{App.Config.BaseUrl}/authorize/login");
            //    if (!response.IsOk)
            //        throw new System.Exception(response.Message);
            //    App.AuthorizeData = new AuthorizeData() { Refresh = response.Data.Refresh_token, Token = response.Data.Access_token };
            //    return response;
            //}
            catch (Exception ex)
            {
                CurrentUser = new User()
                {
                    Id = 24455,
                    DateOfBirth = DateTime.Now,
                    Email = "alen@alen.com",
                    Gender = Gender.Man,
                    IdentificationNumber = "3434NN4343",
                    IDNumber = "123456",
                    Name = "Alen",
                    Password = password,
                    Patronymic = "Beglaryan",
                    PhoneNumber = "+7123123123",
                    SurName = "Surname",
                    Visits = new List<DateTime>()
                    {
                        new DateTime(2021, 04, 28),
                        new DateTime(2021, 04, 30),
                        new DateTime(2021, 03, 31),
                        new DateTime(2000, 04, 20),
                        new DateTime(2020, 04, 22),
                    },
                    Balance = 23450,
                    Cashback = 200,
                    Bonus = 400,
                };
                return new Response()
                {
                    IsOk = true,
                };
            }

        }

        public async Task Logout()
        {
            await Task.Run(() =>
            {
            });
        }
    }
}

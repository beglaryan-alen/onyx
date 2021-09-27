﻿using HttpBroker.Models;
using onyx_Client_UI.Models;
using System.Threading.Tasks;

namespace onyx_Client_UI.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }

        bool IsLoggedIn { get; }
        
        Task<Response> Register(User User);
        
        Task<Response> Login(string username, string password);

        Task Logout();
    }
}
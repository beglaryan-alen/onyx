using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestServer.Models.Register;

namespace TestServer.Models.Response
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public User User { get; set; }
    }
}

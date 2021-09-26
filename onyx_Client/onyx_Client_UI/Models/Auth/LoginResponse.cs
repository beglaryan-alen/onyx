using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI.Models.Auth
{
    class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public User User { get; set; }
    }
}

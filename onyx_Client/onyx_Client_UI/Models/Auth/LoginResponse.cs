using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI.Models.Auth
{
    class LoginResponse
    {
        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
        public string Id_token { get; set; }
        public DateTime Expires_at { get; set; }
    }
}

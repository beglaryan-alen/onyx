using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI.Models.Auth
{
    class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Grant_type { get; set; }
    }
}

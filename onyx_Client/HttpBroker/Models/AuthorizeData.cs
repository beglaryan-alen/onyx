using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpBroker.Models
{
    public class AuthorizeData
    {
        public string Token { get; set; }
        public string Refresh { get; set; }
    }
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Grant_type { get; set; }
    }
}

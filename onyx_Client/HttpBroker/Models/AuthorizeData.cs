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
}

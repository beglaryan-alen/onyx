using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI.Models.UserProfile
{
    public class BalanceResponse
    {
        public decimal Current { get; set; }
        public decimal Cashback { get; set; }
        public decimal Bonus { get; set; }
    }
    public class UserProfileResponse
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Code { get; set; }
    }
}

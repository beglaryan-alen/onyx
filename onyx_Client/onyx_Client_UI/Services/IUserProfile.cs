using onyx_Client_UI.Models.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI.Services
{
    public interface IUserProfile
    {

        public Task<BalanceResponse> FetchBalance(string version="v1");
        public Task<IEnumerable<DateTime>> FetchVisitHistory(string version = "v1");

        public Task<UserProfileResponse> FetchUserProfile(string version = "v1");
    }
}

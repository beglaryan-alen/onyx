using onyx_Client_UI.Models.Catalog;
using onyx_Client_UI.Models.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI.Services
{
    class UserProfile : IUserProfile
    {
        public Task<BalanceResponse> FetchBalance(string version="v1")
        {
            return Task.Run(() =>
            {
                var response = App.HttpClient.Get<BalanceResponse>($"{App.Config.BaseUrl}/api/{version}/Balance");
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
        }

        public Task<UserProfileResponse> FetchUserProfile(string version = "v1")
        {
            return Task.Run(() =>
            {
                var response = App.HttpClient.Get<UserProfileResponse>($"{App.Config.BaseUrl}/api/{version}/UserProfile");
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
        }

        public Task<IEnumerable<DateTime>> FetchVisitHistory(string version = "v1")
        {
            return Task.Run(() =>
            {
                var response = App.HttpClient.Get<IEnumerable<DateTime>>($"{App.Config.BaseUrl}/api/{version}/VisitHistory");
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
        }
    }
}

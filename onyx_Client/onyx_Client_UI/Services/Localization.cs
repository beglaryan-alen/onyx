using onyx_Client_UI.Models.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI.Services
{
    class Localization : ILocalization
    {
        public Task<IEnumerable<string>> FetchKeys(string version = "v1")
        {
            return Task.Run(() =>
            {
                var response = App.HttpClient.Get<IEnumerable<string>>($"{App.Config.BaseUrl}/api/{version}/Languages/Keys");
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
        }

        public Task<IEnumerable<LanguageResponseData>> FetchLanguages(string version = "v1")
        {
            return Task.Run(() =>
            {
                var response = App.HttpClient.Get<IEnumerable<LanguageResponseData>>($"{App.Config.BaseUrl}/api/{version}/Languages/anyId");
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
        }

        public Task<IEnumerable<LanguageVersionResponse>> Versions(string version = "v1")
        {
            return Task.Run(() =>
            {
                var response = App.HttpClient.Get<IEnumerable<LanguageVersionResponse>>($"{App.Config.BaseUrl}/api/{version}/Versions");
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
        }
    }
}

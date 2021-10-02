using onyx_Client_UI.Models.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI.Services
{
    public interface ILocalization
    {
        public Task<IEnumerable<LanguageResponseData>> FetchLanguages(string version = "v1");
        public Task<IEnumerable<string>> FetchKeys(string version = "v1");
        public Task<IEnumerable<LanguageVersionResponse>> Versions(string version = "v1");
    }
}

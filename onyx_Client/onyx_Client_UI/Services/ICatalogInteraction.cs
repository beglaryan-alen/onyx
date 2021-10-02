using HttpBroker.Models;
using onyx_Client_UI.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onyx_Client_UI.Services
{
    public interface ICatalogInteraction
    {
        public Task<IEnumerable<ApplicationCatalogResponse>> FetchGames(string version = "v1");
        public Task<IEnumerable<ApplicationCatalogResponse>> FetchSoft(string version = "v1");
    }
}

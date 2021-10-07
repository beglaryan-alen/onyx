using onyx_Client_UI.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpBroker.Models;

namespace onyx_Client_UI.Services
{
    class CatalogInteraction : ICatalogInteraction
    {
        public Task<IEnumerable<ApplicationCatalogResponse>> FetchGames(string version = "v1")
        {
            try
            {
                var response = App.HttpClient.Get<IEnumerable<ApplicationCatalogResponse>>($"{App.Config.BaseUrl}/Catalog/Games/anyId", App.AuthorizeData);
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return Task.Run(() => response.Data);
            }
            catch (Exception)
            {
                IEnumerable<ApplicationCatalogResponse> games = new List<ApplicationCatalogResponse>()
                {
                    new ApplicationCatalogResponse()
                    {

                    },
                    new ApplicationCatalogResponse()
                    {

                    },
                };

                return Task.Run(() => games);
            }

        }

        public Task<IEnumerable<ApplicationCatalogResponse>> FetchSoft(string version = "v1")
        {
            try
            {
                var response = App.HttpClient.Get<IEnumerable<ApplicationCatalogResponse>>($"{App.Config.BaseUrl}/Catalog/Soft/anyId", App.AuthorizeData);
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return Task.Run(() => response.Data);
            }
            catch (Exception)
            {
                IEnumerable<ApplicationCatalogResponse> softs = new List<ApplicationCatalogResponse>()
                {
                    new ApplicationCatalogResponse()
                    {
                        
                    },
                    new ApplicationCatalogResponse()
                    {

                    },
                };
                return Task.Run(() => softs);
            }
                
        }
    }
}

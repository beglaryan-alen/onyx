﻿using onyx_Client_UI.Models.Catalog;
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
            return Task.Run(()=> 
            {
                var response = App.HttpClient.Get<IEnumerable<ApplicationCatalogResponse>>($"{App.Config.BaseUrl}/api/{version}/Catalog/Games/anyId");
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
        }

        public Task<IEnumerable<ApplicationCatalogResponse>> FetchSoft(string version = "v1")
        {
            return Task.Run(() =>
            {
                var response = App.HttpClient.Get<IEnumerable<ApplicationCatalogResponse>>($"{App.Config.BaseUrl}/api/{version}/Catalog/Soft/anyId");
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
        }
    }
}
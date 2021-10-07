using onyx_Client_UI.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpBroker.Models;

namespace onyx_Client_UI.Services
{
    public class CatalogInteraction : ICatalogInteraction
    {
        public Task<IEnumerable<ApplicationCatalogResponse>> FetchGames(string version = "v1")
        {
            try
            {
<<<<<<< HEAD
                    var response = App.HttpClient.Get<IEnumerable<ApplicationCatalogResponse>>($"{App.Config.BaseUrl}/api/{version}/Catalog/Games/anyId", App.AuthorizeData);
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
                        AppUrl=@"steam://rungameid/394360",
                        SoftUrl=@"C:\Program Files (x86)\Steam\steam.exe",
                        ImageUrl = @"D:\Onyx_photos\hoi4.png",
                    },
                    new ApplicationCatalogResponse()
                    {
                        AppUrl=@"--launch-product=league_of_legends --launch-patchline=live",
                        SoftUrl=@"C:\Riot Games\Riot Client\RiotClientServices.exe",
                        ImageUrl = @"D:\Onyx_photos\lol.png",
                    },
                    new ApplicationCatalogResponse()
                    {
                        AppUrl=@"steam://rungameid/730",
                        SoftUrl=@"C:\Program Files (x86)\Steam\steam.exe",
                        ImageUrl = @"D:\Onyx_photos\csgo.png",
                    },
                };
                return Task.Run(() => games);
            }
=======
                var response = App.HttpClient.Get<IEnumerable<ApplicationCatalogResponse>>($"{App.Config.BaseUrl}/Catalog/Games/anyId",App.AuthorizeData);
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf
        }

        public Task<IEnumerable<ApplicationCatalogResponse>> FetchSoft(string version = "v1")
        {
            try
            {
                    var response = App.HttpClient.Get<IEnumerable<ApplicationCatalogResponse>>($"{App.Config.BaseUrl}/api/{version}/Catalog/Soft/anyId", App.AuthorizeData);
                    if (!response.IsOk)
                        throw new Exception(response.Message);
                    return Task.Run(() => response.Data);
            }
            catch (Exception)
            {
<<<<<<< HEAD
                IEnumerable<ApplicationCatalogResponse> softs = new List<ApplicationCatalogResponse>()
                {
                    new ApplicationCatalogResponse()
                    {
                        AppUrl=@"C:\Program Files (x86)\Steam\steam.exe",
                        ImageUrl = @"D:\Onyx_photos\steam.png",
                    },
                    new ApplicationCatalogResponse()
                    {
                        AppUrl=@"C:\Users\Alen\AppData\Local\Discord\app-1.0.9003\Discord.exe",
                        ImageUrl = @"D:\Onyx_photos\discord.png",
                    },
                };
                return Task.Run(() => softs);
            }
            
=======
                var response = App.HttpClient.Get<IEnumerable<ApplicationCatalogResponse>>($"{App.Config.BaseUrl}/Catalog/Soft/anyId",App.AuthorizeData);
                if (!response.IsOk)
                    throw new Exception(response.Message);
                return response.Data;
            });
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf
        }
    }
}

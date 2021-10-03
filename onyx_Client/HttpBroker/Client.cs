using HttpBroker.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace HttpBroker
{
    public class Client
    {


        private static Client instance;
        private HttpClient client;

        private Client()
        {
        }

        public static Client getClient()
        {

            if (instance == null)
                instance = new Client();
            return instance;
        }

        public R Post<T, R>(T body, string url, AuthorizeData ad = null) where R : Response
        {
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            client = new System.Net.Http.HttpClient();
            if (ad != null)
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ad.Token);
            var response = client.PostAsync(url, data).Result;
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return (R)new Response($"Error. Status code:{response.StatusCode}");
            return JsonConvert.DeserializeObject<R>(response.Content.ReadAsStringAsync().Result);
        }

        public DataResponse<T> Get<T>(string url, AuthorizeData ad = null)
        {
            client = new System.Net.Http.HttpClient();
            if (ad != null)
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ad.Token);
            var result = client.GetAsync(url).Result;
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                return new DataResponse<T>() { IsOk = false, Message = $"Error. Status code: {result.StatusCode}" };
            return JsonConvert.DeserializeObject<DataResponse<T>>(result.Content.ReadAsStringAsync().Result);
        }



    }
}

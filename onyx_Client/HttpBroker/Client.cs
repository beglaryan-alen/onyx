using HttpBroker.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace HttpBroker
{
    public class Client
    {
        public static R Post<T, R>(T body, string url) where R : Response
        {
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new System.Net.Http.HttpClient();
            var response = client.PostAsync(url, data).Result;
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return (R)new Response($"Error. Status code:{response.StatusCode}");
            return JsonConvert.DeserializeObject<R>(response.Content.ReadAsStringAsync().Result);
        }

        public static DataResponse<T> Get<T>(string url)
        {
            var client = new System.Net.Http.HttpClient();
            var result = client.GetAsync(url).Result;
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                return new DataResponse<T>() { IsOk = false, Message = $"Error. Status code: {result.StatusCode}" };
            return JsonConvert.DeserializeObject<DataResponse<T>>(result.Content.ReadAsStringAsync().Result);
        }



    }
}

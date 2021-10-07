using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpBroker.Models
{
    public class Response
    {

        public Response()
        {

        }
        public Response(string message)
        {
            Message = message;
        }
        public Response(Exception ex)
        {
            Message = ex.Message;
        }
        public bool IsOk { get; set; }
        public static Response OK => new Response() { IsOk = true };
        public string Message { get; set; }

        public static Response BadResponse(string message) => new Response(message) { IsOk=false};
        public static Response BadResponse(Exception message) => new Response(message) { IsOk=false};
    }

    

    public class DataResponse<T> : Response
    {
        public T Data { get; set; }
    }

   public class LoginResponse
    {
        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
        public string Id_token { get; set; }
        public DateTime Expires_at { get; set; }
    }


}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestServer.Models.Register;
using TestServer.Models.Response;

namespace TestServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthorizeController : ControllerBaseEx
    {
        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            return SafeRun(_ =>
            {

                return HttpBroker.Models.Response.OK;
            });
        }

        [HttpPost]
        public IActionResult Login()
        {
            return SafeRun(_ =>
            {
                return new HttpBroker.Models.DataResponse<LoginResponse>
                {
                    IsOk = true,
                    Data = new LoginResponse()
                    {
                        RefreshToken = "refresh_token",
                        Role = "user",
                        Token = "token"
                    }
                };
            });
        }
    }
}

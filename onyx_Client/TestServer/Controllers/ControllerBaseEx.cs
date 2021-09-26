using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Controllers
{
    public class ControllerBaseEx:Controller
    {

        protected IActionResult SafeRun(Func<string, object> action)
        {
            try
            {
                var resp = action(User?.Identity?.Name);
                return new JsonResult(resp);
            }
            catch (Exception ex)
            {
                return new JsonResult(HttpBroker.Models.Response.BadResponse(ex.Message));
            }
        }
    }
}

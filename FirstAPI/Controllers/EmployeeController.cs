using FirstAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [MyHeaderFilter]
        public string SayHello()
        {
            return "Hello World";
        }
        [HttpGet]
        public string SayWelcome()
        {
            return "Hello World- Welcome - ";
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
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

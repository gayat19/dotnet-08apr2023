using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync<User>("http://localhost:5165/api/User/Login", user);
            if(response.IsSuccessStatusCode)
            {

                var data = await response.Content.ReadFromJsonAsync<User>();
                HttpContext.Session.SetString("token", data.Token);
                return RedirectToAction("Index", "Weather");

            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
          
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using System.Net.Http.Headers;

namespace MVCApp.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("http://localhost:5165/WeatherForecast");
            if (response.IsSuccessStatusCode)
            {

                var data = await response.Content.ReadFromJsonAsync<IList<WeatherForecast>>();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
           
        }
    }
}

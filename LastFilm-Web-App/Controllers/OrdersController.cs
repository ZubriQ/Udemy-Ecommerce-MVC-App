using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers
{
    public class CinemasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

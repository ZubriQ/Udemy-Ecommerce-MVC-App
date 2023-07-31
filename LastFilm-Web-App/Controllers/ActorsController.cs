using LastFilm_Web_App.Data;
using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var actors = _context.Actors.ToList();
            return View(actors);
            //return View();
        }
    }
}

using LastFilm_Web_App.Data.Services;
using LastFilm_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LastFilm_Web_App.Controllers;

public class MoviesController : Controller
{
    private readonly IMoviesService _service;

    public MoviesController(IMoviesService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await _service.GetAllAsync(n => n.Cinema);
        return View(movies);
    }

    // GET: movies/details/1
    public async Task<IActionResult> Details(int id)
    {
        var movie = await _service.GetMovieByIdAsync(id);
        return View(movie);
    }

    // GET: movies/create
    public async Task<IActionResult> Create()
    {
        var movieDropdowns = await _service.GetNewMovieDropdownValuesAsync();

        ViewBag.Cinemas = new SelectList(movieDropdowns.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdowns.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdowns.Actors, "Id", "FullName");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewMovieVM movie)
    {
        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownValuesAsync();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(movie);
        }

        await _service.AddNewMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }
}

using LastFilm_Web_App.Data.Services;
using LastFilm_Web_App.Data.Static;
using LastFilm_Web_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LastFilm_Web_App.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class MoviesController : Controller
{
    private readonly IMoviesService _service;

    public MoviesController(IMoviesService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var movies = await _service.GetAllAsync(n => n.Cinema);
        return View(movies);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Filter(string searchString)
    {
        var movies = await _service.GetAllAsync(n => n.Cinema);

        if (!string.IsNullOrEmpty(searchString))
        {
            var filteredMovies = movies
                .Where(n =>
                    n.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    n.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            return View("Index", filteredMovies);
        }

        return View("Index", movies);
    }

    // GET: movies/details/1
    [AllowAnonymous]
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

    // GET: movies/edit/1
    public async Task<IActionResult> Edit(int id)
    {
        if (await _service.GetByIdAsync(id) is not Movie movie)
        {
            return View("NotFound");
        }

        var response = new NewMovieVM()
        {
            Id = movie.Id,
            Name = movie.Name,
            Description = movie.Description,
            Price = movie.Price,
            ImageURL = movie.ImageURL,
            MovieCategory = movie.MovieCategory,
            CinemaId = movie.CinemaId,
            ProducerId = movie.ProducerId,
            EndDate = movie.EndDate,
            StartDate = movie.StartDate,
            ActorIds = movie.ActorsMovies.Select(a => a.ActorId).ToList(),
        };

        var movieDropdownsData = await _service.GetNewMovieDropdownValuesAsync();

        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, NewMovieVM movie)
    {
        if (id != movie.Id)
        {
            return View("NotFound");
        }

        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownValuesAsync();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(movie);
        }

        await _service.UpdateMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }
}

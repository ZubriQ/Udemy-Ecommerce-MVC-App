using LastFilm_Web_App.Data;
using LastFilm_Web_App.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
}

using LastFilm_Web_App.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers;

public class ActorsController : Controller
{
    private readonly IActorsService _service;

    public ActorsController(IActorsService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var actors = await _service.GetAllAsync();
        return View(actors);
    }

    // Get: Actors/Create
    public IActionResult Create()
    {
        return View();
    }
}

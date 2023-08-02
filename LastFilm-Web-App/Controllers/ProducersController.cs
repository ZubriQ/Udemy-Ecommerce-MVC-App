using LastFilm_Web_App.Data.Services;
using LastFilm_Web_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers;

public class ProducersController : Controller
{
    private readonly IProducersService _service;

    public ProducersController(IProducersService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var producers = await _service.GetAllAsync();
        return View(producers);
    }

    // GET: producers/details/1
    public async Task<IActionResult> Details(int id)
    {
        if (await _service.GetByIdAsync(id) is Producer producer)
        {
            return View(producer);
        }

        return View(nameof(NotFound));
    }
}

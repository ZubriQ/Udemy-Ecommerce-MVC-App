using LastFilm_Web_App.Data.Services;
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
}

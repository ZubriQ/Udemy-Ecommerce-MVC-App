using LastFilm_Web_App.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers;

public class CinemasController : Controller
{
    private readonly ICinemasService _service;

    public CinemasController(ICinemasService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var cinemas = await _service.GetAllAsync();
        return View(cinemas);
    }
}

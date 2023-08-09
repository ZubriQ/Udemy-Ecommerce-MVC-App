using LastFilm_Web_App.Data.Services;
using LastFilm_Web_App.Models;
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

    // GET: cinemas/create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
    {
        if (!ModelState.IsValid)
        {
            return View(cinema);
        }

        await _service.AddAsync(cinema);
        return RedirectToAction("Index");
    }

    // GET: cinemas/details/1
    public async Task<IActionResult> Details(int id)
    {
        if (await _service.GetByIdAsync(id) is not Cinema cinema)
        {
            return View("NotFound");
        }

        return View(cinema);
    }
}

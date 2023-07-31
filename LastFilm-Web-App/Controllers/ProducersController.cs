using LastFilm_Web_App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastFilm_Web_App.Controllers;

public class ProducersController : Controller
{
    private readonly AppDbContext _context;

    public ProducersController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var producers = await _context.Producers.ToListAsync();
        return View(producers);
    }
}

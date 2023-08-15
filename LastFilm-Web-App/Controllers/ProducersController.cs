using LastFilm_Web_App.Data.Services;
using LastFilm_Web_App.Data.Static;
using LastFilm_Web_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class ProducersController : Controller
{
    private readonly IProducersService _service;

    public ProducersController(IProducersService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var producers = await _service.GetAllAsync();
        return View(producers);
    }

    // GET: producers/details/1
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        if (await _service.GetByIdAsync(id) is Producer producer)
        {
            return View(producer);
        }

        return View(nameof(NotFound));
    }

    // GET: producers/create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
    {
        if (!ModelState.IsValid)
        {
            return View(producer);
        }

        await _service.AddAsync(producer);
        return RedirectToAction(nameof(Index));
    }

    // GET: producers/edit/1
    public async Task<IActionResult> Edit(int id)
    {
        if (await _service.GetByIdAsync(id) is Producer producer)
        {
            return View(producer);
        }

        return View("NotFound");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
    {
        if (!ModelState.IsValid)
        {
            return View(producer);
        }

        if (id == producer.Id)
        {
            await _service.UpdateByIdAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        return View(producer);
    }

    // GET: producers/delete/1
    public async Task<IActionResult> Delete(int id)
    {
        if (await _service.GetByIdAsync(id) is Producer producer)
        {
            return View(producer);
        }

        return View("NotFound");
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (await _service.GetByIdAsync(id) is not Producer producer)
        {
            return View("NotFound");
        }

        await _service.DeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

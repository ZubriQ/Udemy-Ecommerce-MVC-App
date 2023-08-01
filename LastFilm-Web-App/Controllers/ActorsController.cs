using LastFilm_Web_App.Data.Services;
using LastFilm_Web_App.Models;
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

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }

        _service.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }

    // Get: Actors/Details/1
    public async Task<IActionResult> Details(int id)
    {
        if (await _service.GetByIdAsync(id) is not Actor actor)
        {
            return View("Empty");
        }
        return View(actor);
    }


    // Get: Actors/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        if (await _service.GetByIdAsync(id) is not Actor actor)
        {
            return View("NotFound");
        }
        return View(actor);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }

        await _service.UpdateAsync(id, actor);
        return RedirectToAction(nameof(Index));
    }

    // Get: Actors/Delete/1
    public async Task<IActionResult> Delete(int id)
    {
        if (await _service.GetByIdAsync(id) is not Actor actor)
        {
            return View("NotFound");
        }
        return View(actor);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (await _service.GetByIdAsync(id) is not Actor actor)
        {
            return View("NotFound");
        }

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

using LastFilm_Web_App.Data.Services;
using LastFilm_Web_App.Data.Static;
using LastFilm_Web_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class ActorsController : Controller
{
    private readonly IActorsService _service;

    public ActorsController(IActorsService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var actors = await _service.GetAllAsync();
        return View(actors);
    }

    // GET: actors/create
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

    // GET: actors/details/1
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        if (await _service.GetByIdAsync(id) is not Actor actor)
        {
            return View("NotFound");
        }
        return View(actor);
    }


    // GET: actors/edit/1
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

        await _service.UpdateByIdAsync(id, actor);
        return RedirectToAction(nameof(Index));
    }

    // GET: actors/delete/1
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

        await _service.DeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

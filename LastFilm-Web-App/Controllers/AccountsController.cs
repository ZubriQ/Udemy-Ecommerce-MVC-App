using LastFilm_Web_App.Data;
using LastFilm_Web_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers;

public class AccountsController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly AppDbContext _context;

    public AccountsController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
}

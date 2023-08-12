using LastFilm_Web_App.Data.Cart;
using LastFilm_Web_App.Data.Services;
using LastFilm_Web_App.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LastFilm_Web_App.Controllers;

public class OrdersController : Controller
{
    private readonly IMoviesService _moviesService;
    private readonly ShoppingCart _shoppingCart;

    public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart)
    {
        _moviesService = moviesService;
        _shoppingCart = shoppingCart;
    }

    public IActionResult Index()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var response = new ShoppingCartVM()
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
        };

        return View(response);
    }
}

using LastFilm_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace LastFilm_Web_App.Data.Cart;

public class ShoppingCart
{
    public AppDbContext _context { get; set; }

    public string ShoppingCartId { get; set; } = null!;
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } 

    public ShoppingCart(AppDbContext context)
    {
        _context = context;
        ShoppingCartItems = new List<ShoppingCartItem>();
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems
            ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Include(o => o.Movie).ToList());
    }
}

using LastFilm_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace LastFilm_Web_App.Data.Cart;

public class ShoppingCart
{
    private readonly AppDbContext _context;

    public string ShoppingCartId { get; set; } = null!;
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public ShoppingCart(AppDbContext context)
    {
        _context = context;
        ShoppingCartItems = new List<ShoppingCartItem>();
    }

    public static ShoppingCart GetShoppingCart(IServiceProvider provider)
    {
        ISession session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = provider.GetService<AppDbContext>();

        string cartId = session.GetString("CardId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);
        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }

    public void AddItemToCart(Movie movie)
    {
        var shoppingCartItem = _context.ShoppingCartItems
            .FirstOrDefault(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Movie = movie,
                Amount = 1
            };
            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount += 1;
        }
        _context.SaveChanges();
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems
            ?? (ShoppingCartItems = _context.ShoppingCartItems
            .Where(s => s.ShoppingCartId == ShoppingCartId)
            .Include(o => o.Movie)
            .ToList());
    }

    public double GetShoppingCartTotal()
    {
        return _context.ShoppingCartItems
            .Where(s => s.ShoppingCartId == ShoppingCartId)
            .Select(m => m.Movie.Price * m.Amount)
            .Sum();
    }

    public void RemoveItemFromCart(Movie movie)
    {
        var shoppingCartItem = _context.ShoppingCartItems
            .FirstOrDefault(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount -= 1;
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }
        _context.SaveChanges();
    }
}

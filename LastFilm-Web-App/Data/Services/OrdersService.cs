using LastFilm_Web_App.Data.Static;
using LastFilm_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace LastFilm_Web_App.Data.Services;

public class OrdersService : IOrdersService
{
    private readonly AppDbContext _context;

    public OrdersService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
    {
        var orders = await _context.Orders
            .Include(i => i.OrderItems)
            .ThenInclude(m => m.Movie)
            .Include(u => u.User)
            .ToListAsync();

        if (userRole != UserRoles.Admin)
        {
            orders = orders.Where(n => n.UserId == userId).ToList();
        }

        return orders;
    }

    public async Task StoreOrderAsync(List<ShoppingCartItem> cartItems, string userId, string userEmailAddress)
    {
        var order = new Order()
        {
            UserId = userId,
            Email = userEmailAddress,
        };
        await _context.AddAsync(order);
        await _context.SaveChangesAsync();

        foreach (var item in cartItems)
        {
            var orderItem = new OrderItem()
            {
                Amount = item.Amount,
                MovieId = item.Movie.Id,
                OrderId = order.Id,
                Price = item.Movie.Price,
            };
            await _context.OrderItems.AddAsync(orderItem);
        }
        await _context.SaveChangesAsync();
    }
}

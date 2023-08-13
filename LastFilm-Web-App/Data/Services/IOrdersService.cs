using LastFilm_Web_App.Models;

namespace LastFilm_Web_App.Data.Services;

public interface IOrdersService
{
    Task StoreOrderAsync(List<ShoppingCartItem> cartItems, string userId, string userEmailAddress);
    Task<List<Order>> GetOrdersByUserIdAsync(string userId);
}

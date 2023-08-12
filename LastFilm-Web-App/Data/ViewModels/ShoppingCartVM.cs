using LastFilm_Web_App.Data.Cart;

namespace LastFilm_Web_App.Data.ViewModels;

public class ShoppingCartVM
{
    public ShoppingCart ShoppingCart { get; set; } = null!;
    public double ShoppingCartTotal { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastFilm_Web_App.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    public ICollection<OrderItem> OrderItems { get; set;} = new HashSet<OrderItem>();
}

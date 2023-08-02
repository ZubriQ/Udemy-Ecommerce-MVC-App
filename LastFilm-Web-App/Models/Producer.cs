using LastFilm_Web_App.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace LastFilm_Web_App.Models;

public class Producer : IEntityBase
{
    public Producer()
    {
        Movies = new HashSet<Movie>();
    }

    [Key]
    public int Id { get; set; }

    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage = "Profile Picture is required")]
    public string ProfilePictureURL { get; set; } = string.Empty;

    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "Biography")]
    [Required(ErrorMessage = "Biography is required")]
    public string Bio { get; set; } = string.Empty;

    public ICollection<Movie> Movies { get; set; }
}

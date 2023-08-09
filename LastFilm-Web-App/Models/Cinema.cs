using LastFilm_Web_App.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace LastFilm_Web_App.Models;

public class Cinema : IEntityBase
{
    public Cinema()
    {
        Movies = new HashSet<Movie>();
    }

    [Key]
    public int Id { get; set; }

    [Display(Name = "Cinema Logo")]
    [Required(ErrorMessage = "Cinema logo is required")]
    public string Logo { get; set; } = string.Empty;

    [Display(Name = "Cinema Name")]
    [Required(ErrorMessage = "Cinema name is required")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Description")]
    [Required(ErrorMessage = "Cinema description is required")]
    public string Description { get; set; } = string.Empty;

    public ICollection<Movie> Movies { get; set; }
}

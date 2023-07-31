using System.ComponentModel.DataAnnotations;

namespace LastFilm_Web_App.Models;

public class Cinema
{
    public Cinema()
    {
        Movies = new HashSet<Movie>();
    }

    [Key]
    public int Id { get; set; }

    [Display(Name = "Cinema Logo")]
    public string Logo { get; set; } = string.Empty;

    [Display(Name = "Cinema Name")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;

    public ICollection<Movie> Movies { get; set; }
}

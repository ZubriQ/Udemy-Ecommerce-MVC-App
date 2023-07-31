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
    public string Logo { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Movie> Movies { get; set; }
}

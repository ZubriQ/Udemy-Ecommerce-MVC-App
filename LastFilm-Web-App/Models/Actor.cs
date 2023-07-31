using System.ComponentModel.DataAnnotations;

namespace LastFilm_Web_App.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }
    public string ProfilePictureURL { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;

    public ICollection<ActorMovie> ActorsMovies { get; set; }
}

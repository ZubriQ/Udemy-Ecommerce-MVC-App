using System.ComponentModel.DataAnnotations;

namespace LastFilm_Web_App.Models;

public class Actor
{
    public Actor()
    {
        ActorsMovies = new HashSet<ActorMovie>();
    }

    [Key]
    public int Id { get; set; }

    [Display(Name = "Profile Picture")]
    public string ProfilePictureURL { get; set; } = string.Empty;

    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "Biography")]
    public string Bio { get; set; } = string.Empty;

    public ICollection<ActorMovie> ActorsMovies { get; set; }
}

using LastFilm_Web_App.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastFilm_Web_App.Models;

public class Movie
{
    public Movie()
    {
        ActorsMovies = new HashSet<ActorMovie>();
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public string ImageURL { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public MovieCategory MovieCategory { get; set; }

    public int CinemaId { get; set; }
    public Cinema Cinema { get; set; } = null!;

    public int ProducerId { get; set; }
    public Producer Producer { get; set; } = null!;

    public ICollection<ActorMovie> ActorsMovies { get; set; }

}

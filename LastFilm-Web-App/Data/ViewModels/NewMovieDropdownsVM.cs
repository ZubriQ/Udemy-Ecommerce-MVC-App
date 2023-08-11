using LastFilm_Web_App.Models;

namespace LastFilm_Web_App.Data.ViewModels;

public class NewMovieDropdownsVM
{
    public NewMovieDropdownsVM()
    {
        Producers = new List<Producer>();
        Cinemas = new List<Cinema>();
        Actors = new List<Actor>();
    }

    public List<Producer> Producers { get; set; }
    public List<Cinema> Cinemas { get; set; }
    public List<Actor> Actors { get; set; }
}

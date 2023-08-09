using LastFilm_Web_App.Data.Base;
using LastFilm_Web_App.Models;

namespace LastFilm_Web_App.Data.Services;

public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
{
    public MoviesService(AppDbContext context) : base(context) { }
}

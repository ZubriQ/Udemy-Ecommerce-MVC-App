using LastFilm_Web_App.Data.Base;
using LastFilm_Web_App.Data.ViewModels;
using LastFilm_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace LastFilm_Web_App.Data.Services;

public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
{
    private readonly AppDbContext _context;

    public MoviesService(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var movie = await _context.Movies
            .Include(c => c.Cinema)
            .Include(p => p.Producer)
            .Include(am => am.ActorsMovies)
            .ThenInclude(a => a.Actor)
            .FirstOrDefaultAsync(m => m.Id == id);

        return movie!;
    }

    public async Task<NewMovieDropdownsVM> GetNewMovieDropdownValues()
    {
        var response = new NewMovieDropdownsVM()
        {
            Actors = await _context.Actors.OrderBy(a => a.FullName).ToListAsync(),
            Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync(),
            Producers = await _context.Producers.OrderBy(p => p.FullName).ToListAsync(),
        };

        return response;
    }
}

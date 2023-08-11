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

    public async Task<NewMovieDropdownsVM> GetNewMovieDropdownValuesAsync()
    {
        var response = new NewMovieDropdownsVM()
        {
            Actors = await _context.Actors.OrderBy(a => a.FullName).ToListAsync(),
            Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync(),
            Producers = await _context.Producers.OrderBy(p => p.FullName).ToListAsync(),
        };

        return response;
    }

    public async Task AddNewMovieAsync(NewMovieVM data)
    {
        var newMovie = new Movie()
        {
            Name = data.Name,
            Description = data.Description,
            Price = data.Price,
            ImageURL = data.ImageURL,
            CinemaId = data.CinemaId,
            StartDate = data.StartDate,
            EndDate = data.EndDate,
            MovieCategory = data.MovieCategory,
            ProducerId = data.ProducerId,
        };

        await _context.Movies.AddAsync(newMovie);
        await _context.SaveChangesAsync();

        foreach (int actorId in data.ActorIds)
        {
            var actorMovie = new ActorMovie()
            {
                ActorId = actorId,
                MovieId = newMovie.Id,
            };
            await _context.ActorsMovies.AddAsync(actorMovie);
        }
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMovieAsync(NewMovieVM data)
    {
        if (await _context.Movies.FirstOrDefaultAsync(m => m.Id == data.Id) is Movie movie)
        {
            movie.Name = data.Name;
            movie.Description = data.Description;
            movie.Price = data.Price;
            movie.ImageURL = data.ImageURL;
            movie.CinemaId = data.CinemaId;
            movie.StartDate = data.StartDate;
            movie.EndDate = data.EndDate;
            movie.MovieCategory = data.MovieCategory;
            movie.ProducerId = data.ProducerId;
            await _context.SaveChangesAsync();
        }

        var existingActors = _context.ActorsMovies.Where(am => am.MovieId == data.Id);
        _context.ActorsMovies.RemoveRange(existingActors);
        await _context.SaveChangesAsync();

        foreach (int actorId in data.ActorIds)
        {
            var actorMovie = new ActorMovie()
            {
                ActorId = actorId,
                MovieId = data.Id,
            };
            await _context.ActorsMovies.AddAsync(actorMovie);
        }
        await _context.SaveChangesAsync();
    }
}

using LastFilm_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace LastFilm_Web_App.Data.Services;

public class ActorsService : IActorsService
{
    private readonly AppDbContext _context;

    public ActorsService(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Actor actor)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Actor>> GetAllAsync()
    {
        var actors = await _context.Actors.ToListAsync();
        return actors;
    }

    public Actor GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Actor Update(int id, Actor newActor)
    {
        throw new NotImplementedException();
    }
}

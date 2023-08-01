using LastFilm_Web_App.Models;

namespace LastFilm_Web_App.Data.Services;

public interface IActorsService
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Task<Actor> GetByIdAsync(int id);
    Task AddAsync(Actor actor);
    Actor Update(int id, Actor newActor);
    void Delete(int id);
}

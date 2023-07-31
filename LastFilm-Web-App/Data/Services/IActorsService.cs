using LastFilm_Web_App.Models;

namespace LastFilm_Web_App.Data.Services;

public interface IActorsService
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Actor GetById(int id);
    void Add(Actor actor);
    Actor Update(int id, Actor newActor);
    void Delete(int id);
}

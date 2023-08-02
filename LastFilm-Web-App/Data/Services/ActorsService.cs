using LastFilm_Web_App.Data.Base;
using LastFilm_Web_App.Models;

namespace LastFilm_Web_App.Data.Services;

public class ActorsService : EntityBaseRepository<Actor>, IActorsService
{
    public ActorsService(AppDbContext context) : base(context) { }
}

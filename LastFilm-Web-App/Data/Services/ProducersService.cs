using LastFilm_Web_App.Data.Base;
using LastFilm_Web_App.Models;

namespace LastFilm_Web_App.Data.Services;

public class ProducersService : EntityBaseRepository<Producer>, IProducersService
{
    public ProducersService(AppDbContext context) : base(context) { }
}

using LastFilm_Web_App.Data.Base;
using LastFilm_Web_App.Models;

namespace LastFilm_Web_App.Data.Services;

public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
{
    public CinemasService(AppDbContext context) : base(context) { }
}

﻿using LastFilm_Web_App.Data.Base;
using LastFilm_Web_App.Models;

namespace LastFilm_Web_App.Data.Services;

public interface IMoviesService : IEntityBaseRepository<Movie>
{
    Task<Movie> GetMovieByIdAsync(int id);
}
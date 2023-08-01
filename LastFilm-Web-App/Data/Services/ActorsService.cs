﻿using LastFilm_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace LastFilm_Web_App.Data.Services;

public class ActorsService : IActorsService
{
    private readonly AppDbContext _context;

    public ActorsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Actor actor)
    {
        await _context.AddAsync(actor);
        await _context.SaveChangesAsync();
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

    public async Task<Actor> GetByIdAsync(int id)
    {
        return await _context.Actors.FindAsync(id);
    }

    public Actor Update(int id, Actor newActor)
    {
        throw new NotImplementedException();
    }
}

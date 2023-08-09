using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace LastFilm_Web_App.Data.Base;

public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _context;

    public EntityBaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

    public async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        T? entity = await _context.Set<T>().FindAsync(id);
        EntityEntry entry = _context.Entry(entity);
        entry.State = EntityState.Deleted;

        await _context.SaveChangesAsync();
    }

    public async Task UpdateByIdAsync(int id, T newEntity)
    {
        EntityEntry entry = _context.Entry(newEntity);
        entry.State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] expressions)
    {
        IQueryable<T> query = _context.Set<T>();
        query = expressions.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.ToListAsync();
    }
}

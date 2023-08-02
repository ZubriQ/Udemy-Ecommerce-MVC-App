﻿namespace LastFilm_Web_App.Data.Base;

public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateByIdAsync(int id, T newEntity);
    Task DeleteByIdAsync(int id);
}

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;
using Data.Repositories.IRepositories;
using Microsoft.Extensions.Logging;

namespace Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DataContext Context;    
    private readonly ILogger Logger;
    private DbSet<T> DBSet;
    
    public Repository(DataContext context, ILogger logger)
    {
        Context = context;
        DBSet = context.Set<T>();
        Logger = logger;
    }
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
    {
        if (predicate != null) return await DBSet.Where(predicate).ToListAsync<T>();
        return await DBSet.ToListAsync<T>();
    }
    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate) => await DBSet.FirstOrDefaultAsync<T>(predicate);
    public async Task AddAsync(T entity) => await DBSet.AddAsync(entity);        
    public void Update(T entity)
    {
        DBSet.Update(entity);        
    }
    public void Delete(T entity) 
    {
        DBSet.Remove(entity);        
    }
    public async Task DeleteAsyncById(int id) 
    {
        T? movie = await DBSet.FindAsync(id);
        
        if (movie is null) return;
        
        DBSet.Remove(movie);
    }
}
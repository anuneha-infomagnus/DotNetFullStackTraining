using Day09.Data;
using Microsoft.EntityFrameworkCore;

namespace Day09.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext context;
    private readonly DbSet<T> dbSet;

    public Repository(AppDbContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CvAlInstante.Domain.Core;
using CvAlInstante.Domain.Repository;
using CvAlInstante.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CvAlInstante.Infrastructure.Core;

public class BaseRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly CvDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(CvDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<IReadOnlyList<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) 
        => await _dbSet.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}

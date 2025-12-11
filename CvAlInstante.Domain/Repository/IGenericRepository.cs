using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CvAlInstante.Domain.Core;
using System.Linq.Expressions;

namespace CvAlInstante.Domain.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<int> SaveChangesAsync();
}

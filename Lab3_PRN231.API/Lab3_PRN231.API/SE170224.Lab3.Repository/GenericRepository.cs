using Lab3_PRN231.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab3_PRN231.Repository;
public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task Delete(object id);
    Task Delete(TEntity entityToDelete);
    Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<object> ids);
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int pageIndex = 0, int pageSize = 10, string includeProperties = "");
    Task<TEntity?> GetByIdAsync(object id);
    Task InsertAsync(TEntity entity);
    Task<bool> IsExist(object id);
    Task Update(TEntity entityToUpdate);
}

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    internal Lab3Prn231Context context;
    internal DbSet<TEntity> dbSet;

    public GenericRepository(Lab3Prn231Context context)
    {
        this.context = context;
        dbSet = context.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> GetQueryable()
    {
        IQueryable<TEntity> query = dbSet;

        return query;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int pageIndex = 0,
            int pageSize = 10,
            string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        query = query.Skip(pageIndex * pageSize).Take(pageSize);

        return await query.ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<object> ids)
    {
        return await dbSet.Where(entity => ids.Contains(EF.Property<object>(entity, "Id"))).ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(object id) => await dbSet.FindAsync(id);

    public virtual async Task InsertAsync(TEntity entity) => await dbSet.AddAsync(entity);

    public virtual Task Delete(object id)
    {
        TEntity? entityToDelete = dbSet.Find(id);
        if (entityToDelete is not null)
            Delete(entityToDelete);

        return Task.CompletedTask;
    }

    public virtual Task Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);

        return Task.CompletedTask;
    }

    public virtual Task Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public virtual async Task<bool> IsExist(object id)
    {
        return (await GetByIdAsync(id)) is not null;
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        var result = await query.CountAsync();
        return result;
    }
}


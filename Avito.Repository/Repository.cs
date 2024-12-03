using Avito.DataAccess;
using Avito.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avito.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IDbContextFactory<AvitoDbContext> _contextFactory;

    public Repository(IDbContextFactory<AvitoDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IEnumerable<T> GetAll()
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<T>().FirstOrDefault(x => x.Id == id);
    }
    

    public T Save(T entity)
    {
        using var context = _contextFactory.CreateDbContext();
        if (context.Set<T>().Any(x => x.Id == entity.Id))
        {
            entity.ModifiedOnTime = DateTime.UtcNow;
            var result = context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return result.Entity;
        }
        else
        {
            entity.CreatedOnTime = DateTime.UtcNow;
            entity.ModifiedOnTime = entity.CreatedOnTime;
            var result = context.Set<T>().Add(entity);
            context.SaveChanges();
            return result.Entity;
        }
    }

    public void Delete(T entity)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<T>().Attach(entity);
        context.Entry(entity).State = EntityState.Deleted;
        context.SaveChanges();
    }
}
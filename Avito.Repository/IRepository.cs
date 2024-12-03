using Avito.DataAccess.Entities;

namespace Avito.Repository;

public interface IRepository<T> where T : BaseEntity
{
   IEnumerable<T> GetAll();
    T? GetById(int id);
    T Save(T entity);
    void Delete(T entity);
}
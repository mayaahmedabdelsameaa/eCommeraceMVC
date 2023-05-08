using eCommerace.Models;
using System.Linq.Expressions;

namespace eCommerace.Data.Base
{
    public interface IEntityBaseRepository<T> where T:class, IEntityBase, new()
    {
        // get all actors 
        Task<IEnumerable<T>> GettAll(Expression<Func<T, object>> include = null);

        // get actor by id
        Task<T> GetByID(int id,  params Expression<Func<T, object>>[] includes);

        // add an actor 
        Task Add(T entity);

        // update an actor 
        Task Update(int id, T entity);

        // delete an actor 
        Task Delete(int id);
    }
}

using eCommerace.Models;

namespace eCommerace.Data.Base
{
    public interface IEntityBaseRepository<T> where T:class, IEntityBase, new()
    {
        // get all actors 
        Task<IEnumerable<T>> GettAll();

        // get actor by id
        Task<T> GetByID(int id);

        // add an actor 
        Task Add(T entity);

        // update an actor 
        Task Update(int id, T entity);

        // delete an actor 
        Task Delete(int id);
    }
}

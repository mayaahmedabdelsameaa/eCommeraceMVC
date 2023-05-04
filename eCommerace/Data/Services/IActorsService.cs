using eCommerace.Models;

namespace eCommerace.Data.Services
{
    public interface IActorsService
    {
        // get all actors 
        Task<IEnumerable<Actor>> GettAll();

        // get actor by id
        Task<Actor> GetByID(int id);

        // add an actor 
        Task Add(Actor actor);

        // update an actor 
        Task<Actor> Update(int id, Actor newActor);

        // delete an actor 
        Task Delete(int id);
    }
}

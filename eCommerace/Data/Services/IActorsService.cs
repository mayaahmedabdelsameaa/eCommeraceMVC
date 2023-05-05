using eCommerace.Data.Base;
using eCommerace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerace.Data.Services
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        #region old Iservice
        //// get all actors 
        //Task<IEnumerable<Actor>> GettAll();

        //// get actor by id
        //Task<Actor> GetByID(int id);

        //// add an actor 
        //Task Add(Actor actor);

        //// update an actor 
        //Task<Actor> Update(int id, Actor newActor);

        //// delete an actor 
        //Task Delete(int id); 
        #endregion
    }
}

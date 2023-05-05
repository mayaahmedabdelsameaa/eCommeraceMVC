using eCommerace.Data.Base;
using eCommerace.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerace.Data.Services
{
    public class ActorsService :  EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDBContext context) : base(context) { }


        #region old service
        //private readonly AppDBContext _context;
        //public ActorsService(AppDBContext context)
        //{
        //    _context = context;
        //}
        //public async Task Add(Actor actor)
        //{
        //    await _context.AddAsync(actor);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task Delete(int id)
        //{
        //    var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        //    _context.Actors.Remove(actor);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<Actor> GetByID(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
        //    return result;
        //}

        //public async Task<Actor> Update(int id, Actor newActor)
        //{
        //    _context.Update(newActor);
        //    await _context.SaveChangesAsync();
        //    return newActor;
        //}

        //public async Task<IEnumerable<Actor>> GettAll()
        //{
        //    var result = await _context.Actors.ToListAsync();
        //    return result;
        //} 
        #endregion
    }
}

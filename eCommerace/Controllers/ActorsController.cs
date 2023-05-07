using eCommerace.Data;
using eCommerace.Data.Services;
using eCommerace.Data.Static;
using eCommerace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerace.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GettAll();
            return View(allActors);
        }
        // create actor: Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Actors/Create 
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicture,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        //Get: Actors/details/id
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByID(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        // edit actor: Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByID(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }
        // Post: Actors/Edit/1 
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePicture,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }

        // delete actor: Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByID(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }
        // Post: Actors/Delete/1 
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actorDeatils = await _service.GetByID(id);
            if (actorDeatils == null) return View("NotFound");
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

using eCommerace.Data;
using eCommerace.Data.Services;
using eCommerace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerace.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GettAll();
            return View(allCinemas);
        }
        // Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Cinemas/Create 
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.Add(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/details/id
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByID(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        // edit actor: Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByID(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }
        // Post: Cinemas/Edit/1 
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.Update(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        // delete actor: Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByID(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }
        // Post: Cinema/Delete/1 
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _service.GetByID(id);
            if (cinemaDetails == null) return View("NotFound");
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

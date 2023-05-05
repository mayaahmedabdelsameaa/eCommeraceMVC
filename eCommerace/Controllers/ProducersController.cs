using eCommerace.Data;
using eCommerace.Data.Services;
using eCommerace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerace.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GettAll();
            return View(allProducers);
        }
        // Get: Producer/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Producer/Create 
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicture,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.Add(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Producer/details/id
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByID(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        // Get: Producer/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByID(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }
        // Post: Producer/Edit/1 
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePicture,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.Update(id, producer);
            return RedirectToAction(nameof(Index));
        }

        // Get: Producer/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByID(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }
        // Post: Producer/Delete/1 
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producerDeatils = await _service.GetByID(id);
            if (producerDeatils == null) return View("NotFound");
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

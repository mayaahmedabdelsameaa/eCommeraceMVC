﻿using eCommerace.Data;
using eCommerace.Data.Services;
using eCommerace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerace.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GettAll();
            return View(allMovies);
        }
        // Get: Movies/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post: Movies/Create 
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Description,Price,ImageURL,StartDate,EndDate,MovieCategory")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.Add(movie);
            return RedirectToAction(nameof(Index));
        }

        //Get: Movies/details/id
        public async Task<IActionResult> Details(int id)
        {
            var MovieDetails = await _service.GetByID(id);
            if (MovieDetails == null)
            {
                return View("NotFound");
            }
            return View(MovieDetails);
        }

        // Get: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var MovieDetails = await _service.GetByID(id);
            if (MovieDetails == null)
            {
                return View("NotFound");
            }
            return View(MovieDetails);
        }
        // Post: Movies/Edit/1 
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name, Description,Price,ImageURL,StartDate,EndDate,MovieCategory")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _service.Update(id, movie);
            return RedirectToAction(nameof(Index));
        }

        // delete Movie: Get: Movies/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var movieDetails = await _service.GetByID(id);
            if (movieDetails == null)
            {
                return View("NotFound");
            }
            return View(movieDetails);
        }
        // Post: Movies/Delete/1 
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var movieDetails = await _service.GetByID(id);
            if (movieDetails == null) return View("NotFound");
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

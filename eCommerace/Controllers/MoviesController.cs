using eCommerace.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerace.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDBContext _context;
        public MoviesController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.Include(c=>c.Cinema).OrderBy(n=>n.Name).ToListAsync();
            return View(movies);
        }
    }
}

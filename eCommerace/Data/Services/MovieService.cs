using eCommerace.Data.Base;
using eCommerace.Data.ViewModels;
using eCommerace.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerace.Data.Services
{
    public class MovieService:EntityBaseRepository<Movie>, IMoviesService 
    {
        private readonly AppDBContext _context;
        public MovieService(AppDBContext context):base(context)
        {
            _context = context;
        }

        public async Task AddNewMovie(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                ProducerId = data.ProducerId,
                MovieCategory = data.MovieCategory,
                ImageURL = data.ImageURL
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            // add movie actors 
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movieDetails = await _context.Movies
                                .Include(c => c.Cinema)
                                .Include(p => p.Producer)
                                .Include(a => a.Actor_Movies)
                                .ThenInclude(a => a.Actor)
                                .FirstOrDefaultAsync(n => n.Id == id);
            return movieDetails;
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdownValues()
        {
            var response = new NewMovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };
            return response;
        }
    }
}

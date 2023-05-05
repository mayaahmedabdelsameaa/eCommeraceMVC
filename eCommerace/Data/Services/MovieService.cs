using eCommerace.Data.Base;
using eCommerace.Models;

namespace eCommerace.Data.Services
{
    public class MovieService:EntityBaseRepository<Movie>, IMoviesService 
    {
        public MovieService(AppDBContext context):base(context){}
    }
}

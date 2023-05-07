using eCommerace.Data.Base;
using eCommerace.Data.ViewModels;
using eCommerace.Models;
using System.ComponentModel;

namespace eCommerace.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieById(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropdownValues();
        Task AddNewMovie(NewMovieVM data);
        Task Update(NewMovieVM data);
    }
}

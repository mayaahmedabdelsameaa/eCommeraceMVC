using eCommerace.Data.Base;
using eCommerace.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerace.Models
{
    public class NewMovieVM
    {
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be 3 characters to 50")]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descripiton is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Decription must be 3 characters to 100")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "You have to add Price")]
        [Display(Name = "Price in $")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Movie Image is required")]
        [Display(Name = "Image")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Movie StartDate is required")]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Movie EndDate is required")]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Movie Category is required")]
        [Display(Name = "Category")]
        public MovieCategory MovieCategory { get; set; }

        //relarionships
        [Required(ErrorMessage = "Movie actor(s) is required")]
        [Display(Name = "Select actor(s)")]
        public List<int> ActorIds { get; set; }

        [Required(ErrorMessage = "Movie Producer is required")]
        [Display(Name = "Select a Producer")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage = "Movie Cinema is required")]
        [Display(Name = "Select a Cinema")]
        public int CinemaId { get; set; }

    }
}

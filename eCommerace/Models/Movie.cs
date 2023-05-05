using eCommerace.Data.Base;
using eCommerace.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerace.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be 3 characters to 50")]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Decription must be 3 characters to 100")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You have to add Price")]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Image")]
        public string ImageURL { get; set; }
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Category")]
        public MovieCategory MovieCategory { get; set; }

        //relarionships
        public List<Actor_Movie>? Actor_Movies { get; set; }
        public int ProducerId { get; set; }
        
        //[ForeignKey("Producer")]
        public Producer? Producer { get; set; }

        public int CinemaId { get; set; }

        //[ForeignKey("Cinema")]
        public Cinema? Cinema { get; set; }
    }
}

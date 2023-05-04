using eCommerace.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerace.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be 3 characters to 50")]
        public string Name { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Decription must be 3 characters to 100")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You have to add Price")]
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCatogory MovieCatogory { get; set; }

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

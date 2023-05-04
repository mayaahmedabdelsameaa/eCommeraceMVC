using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerace.Models
{
    public class Producer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name ="Picture Profile")]
        [Required(ErrorMessage ="You have to upload the image")]
        public string ProfilePicture { get; set; }
        [Display(Name = "Full Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be 3 characters to 50")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "You have to add Biography")]
        public string Bio { get; set; }

        // relationship
        public List<Movie>? Movies { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerace.Models
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage ="You have to attach the image")]
        public string ProfilePicture  { get; set; }
        [Display(Name ="Full Name")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="The name must be 3 characters to 50")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "You have to add Biography")]
        public string Bio { get; set; }

        //relarionships
        public List<Actor_Movie>? Actor_Movies { get; set; }

    }
}

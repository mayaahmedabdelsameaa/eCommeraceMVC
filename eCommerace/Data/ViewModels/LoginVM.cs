using System.ComponentModel.DataAnnotations;

namespace eCommerace.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Email is required")]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

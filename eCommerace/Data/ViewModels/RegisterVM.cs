using System.ComponentModel.DataAnnotations;

namespace eCommerace.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="Full name is required")]
        public string FullName { get; set; }
        
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Email is required")]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password do not match the confirm password")]
        public string ConfirmPassword { get; set; }
    }
}

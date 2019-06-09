using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class SignUpViewModel
    {
        [Required]
        public string Email { get; set; }
 
        [Required]
        public string Login { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Grasshoppers.Areas.Identity.Models
{
    public class SignUpModel
    {
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
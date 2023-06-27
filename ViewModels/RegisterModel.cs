using System.ComponentModel.DataAnnotations;

namespace MegaHotel.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords doesn't match each other")]
        public string PasswordConfirmation { get; set; }
    }
}

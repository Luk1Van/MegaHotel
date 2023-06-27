using System.ComponentModel.DataAnnotations;

namespace MegaHotel.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

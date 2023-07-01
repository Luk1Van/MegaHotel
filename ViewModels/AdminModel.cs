using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MegaHotel.ViewModels
{
    public class AdminModel
    {
        [Required(ErrorMessage ="Room number is required")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Room Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Image url is required")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Capacity is required")]
        public int CapacityRoom { get; set; }
        [Required(ErrorMessage = "Room type is required")]
        public int TypeRoom { get; set; }
    }
}

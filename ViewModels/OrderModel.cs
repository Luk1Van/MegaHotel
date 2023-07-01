using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MegaHotel.ViewModels
{
    public class OrderModel
    {
        [Required(ErrorMessage = "Arrivale date is required!")]
        public int ArrivaleDate { get; set; }
        [Required(ErrorMessage = "Departure date is required!")]
        public int DateOfDeparture { get; set; }
    }
}

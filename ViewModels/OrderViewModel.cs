using MegaHotel.Models.RoomModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MegaHotel.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Arrivale date is required!")]
        public int ArrivaleDate { get; set; }
        [Required(ErrorMessage = "Departure date is required!")]
        public int DateOfDeparture { get; set; }
        public Room Rooms { get; set; }
        public CapacityRoom CapacityRoom { get; set; }
        public TypeRoom TypeRoom { get; set; }
    }
}

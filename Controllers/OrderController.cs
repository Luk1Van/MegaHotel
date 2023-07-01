using MegaHotel.Models.RoomModels;
using MegaHotel.Services.IHotelServices;
using Microsoft.AspNetCore.Mvc;

namespace MegaHotel.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRoomService _roomService;

        public OrderController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public IActionResult NewOrder(int roomId)
        {
            return View();
        }
    }
}

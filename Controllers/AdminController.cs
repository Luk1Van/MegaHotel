using MegaHotel.Models.RoomModels;
using MegaHotel.Services.IHotelServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MegaHotel.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IRoomService _roomService;

        public AdminController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public IActionResult NewRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRoom(Room newRoom)
        {
            try
            {
                string message = await _roomService.AddNewRoom(newRoom);
                return View(message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex);
            }
        }

        
    }
}

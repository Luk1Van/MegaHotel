using HotelMainApp.ViewModels;
using MegaHotel.Models.RoomModels;
using MegaHotel.Services.HotelServices;
using MegaHotel.Services.IHotelServices;
using MegaHotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaHotel.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IRoomService _roomService;

        public OrderController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public ViewResult NewOrder(int roomId)
        {
            OrderViewModel model = new OrderViewModel()
            {
                Rooms = _roomService.GetRoomById(roomId).FirstOrDefault(),
                CapacityRoom = _roomService.GetCapacity.FirstOrDefault(),
                TypeRoom = _roomService.GetTypeRooms.FirstOrDefault()
            };
            int CapacityId = model.Rooms.CapacityRoomId;
            model.CapacityRoom = _roomService.GetCapacity.FirstOrDefault(c => c.IdCapacity == CapacityId);
            int TypeId = model.Rooms.TypeRoomId;
            model.TypeRoom = _roomService.GetTypeRooms.FirstOrDefault(c => c.IdType == TypeId);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> NewOrder(int roomID, DateTime checkInDate, DateTime departureDate)
        {
            bool checkRoom = _roomService.CheckRoomByDate(checkInDate, departureDate, roomID);
            if(checkRoom == true)
            {
                string username = User.Identity.Name;
                await _roomService.AddNewBooking(checkInDate, departureDate, roomID, username);
                return RedirectToAction("OrderSuccess");
            }
            else
            {
                return View();
            }
        }
        
        public ViewResult OrderSuccess()
        {
            return View(); 
        }
    }
}

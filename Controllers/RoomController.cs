using HotelMainApp.ViewModels;
using MegaHotel.Models.RoomModels;
using MegaHotel.Services.IHotelServices;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HotelMainApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public ViewResult List(int? guestNumber, EnumsRoom? roomType)
        {
            RoomListViewModel model = new RoomListViewModel()
            {
                Rooms = _roomService.GetRooms,
                Capacities = _roomService.GetCapacity,
                Types = _roomService.GetTypeRooms
            };
            
            if (guestNumber.HasValue && roomType.HasValue)
            {
                model.Rooms = _roomService.GetRoomByTypeAndCapacity(guestNumber, roomType);               
                return View(model);
            }
            else if (guestNumber.HasValue)
            {
                model.Rooms = _roomService.GetRoomByCapacity(guestNumber);
                return View(model);
            }
            else if (roomType.HasValue)
            {
                model.Rooms = _roomService.GetRoomByType(roomType);
                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Details(int id)
        {
            RoomListViewModel model = new RoomListViewModel()
            {
                Rooms = _roomService.GetRooms,
                Capacities = _roomService.GetCapacity,
                Types = _roomService.GetTypeRooms
            };

            try
            {
                model.Rooms = _roomService.GetRoomById(id);
                if (model.Rooms == null)
                {
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex);
            }
        }
    }
}

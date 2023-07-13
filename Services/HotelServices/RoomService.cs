using MegaHotel.DataBase;
using MegaHotel.Models.OrderModels;
using MegaHotel.Models.RoomModels;
using MegaHotel.Services.IHotelServices;

namespace MegaHotel.Services.HotelServices
{
    public class RoomService : IRoomService
    {
        private readonly IUserService _userService;

        public HotelDbContext _hotelDb { get; }
        public RoomService(HotelDbContext hotelDb, IUserService userService)
        {
            _hotelDb = hotelDb;
            _userService = userService;
        }
        public IEnumerable<Room> GetRooms => _hotelDb.Rooms;

        public IEnumerable<CapacityRoom> GetCapacity => _hotelDb.CapacityRooms;

        public IEnumerable<TypeRoom> GetTypeRooms => _hotelDb.TypeRooms;

        public IEnumerable<Room> GetRoomById(int id)
        {
            var room = from c in _hotelDb.Rooms
                       where c.IDRoom == id
                       select c;
            return room;
        }

        public IEnumerable<Room> GetRoomByCapacity(int? guestNumber)
        {
            var room = from c in _hotelDb.Rooms
                       where c._CapacityRoom.GuestNumber == guestNumber
                       select c;
            return room;
        }

        public IEnumerable<Room> GetRoomByType(EnumsRoom? roomType)
        {
            var room = from c in _hotelDb.Rooms
                       where c._TypeRoom.RoomType == roomType
                       select c;
            return room;
        }

        public IEnumerable<Room> GetRoomByTypeAndCapacity(int? guestNumber, EnumsRoom? roomType)
        {
            var room = from c in _hotelDb.Rooms
                       where c._CapacityRoom.GuestNumber == guestNumber && c._TypeRoom.RoomType == roomType
                       select c;
            return room;
        }

        public async Task<string> AddNewRoom(Room newRoom)
        {
            if (newRoom != null)
            {
                await _hotelDb.Rooms.AddAsync(newRoom);
                await _hotelDb.SaveChangesAsync();
                string success = "RoomSuccess";
                return success;
            }
            else
            {
                string error = "NewRoom";
                return error;
            }
        }

        public bool CheckRoomByDate(DateTime? checkInDate, DateTime? departureDate, int? roomId)
        {
            var room = (from c in _hotelDb.CalendarRooms
                       where c.RoomCalendarId == roomId && c.Data >= checkInDate && c.Data <= departureDate
                       orderby c.IsAvaible descending
                       select c).LastOrDefault();
            if(room.IsAvaible == true)
            {
                return true;
            }
            return false;
        }

        public async Task AddNewBooking(DateTime checkInDate, DateTime departureDate, int roomId, string userName)
        {
            var userByEmail = _userService.CheckUserEmail(userName).FirstOrDefault();

            Order newOrder = new Order { OrderUserId = userByEmail.UserId };
            await _hotelDb.AddAsync(newOrder);
            await _hotelDb.SaveChangesAsync();

            int orderId = newOrder.OrderID;
            var calendar = (from c in _hotelDb.CalendarRooms
                            where c.RoomCalendarId == roomId && c.Data >= checkInDate && c.Data <= departureDate
                            select c).ToList();
            foreach(var date in calendar)
            {
                date.CalendarOrderId = orderId;
                date.IsAvaible = false;
            }
            await _hotelDb.SaveChangesAsync();
    
        }
    }
}

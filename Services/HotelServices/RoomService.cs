using MegaHotel.DataBase;
using MegaHotel.Models.RoomModels;
using MegaHotel.Services.IHotelServices;

namespace MegaHotel.Services.HotelServices
{
    public class RoomService : IRoomService
    {
        public HotelDbContext _hotelDb { get; }
        public RoomService(HotelDbContext hotelDb)
        {
            _hotelDb = hotelDb;
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
    }
}

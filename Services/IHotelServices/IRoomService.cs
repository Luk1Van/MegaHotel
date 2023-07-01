using MegaHotel.Models.RoomModels;

namespace MegaHotel.Services.IHotelServices
{
    public interface IRoomService
    {
        public IEnumerable<Room> GetRooms { get; }
        public IEnumerable<Room> GetRoomById(int id);
        public IEnumerable<Room> GetRoomByCapacity(int? guestNumber);
        public IEnumerable<Room> GetRoomByTypeAndCapacity(int? guestNumber, EnumsRoom? roomType);
        public IEnumerable<CapacityRoom> GetCapacity { get; }
        public IEnumerable<TypeRoom> GetTypeRooms { get; }
        public IEnumerable<Room> GetRoomByType(EnumsRoom? roomType);
        public Task<string> AddNewRoom(Room newRoom);
    }
}

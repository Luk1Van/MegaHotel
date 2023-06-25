using MegaHotel.Models.RoomModels;


namespace HotelMainApp.ViewModels
{
    public class RoomListViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<CapacityRoom> Capacities { get; set; }
        public IEnumerable<TypeRoom> Types { get; set; }
    }
}

namespace MegaHotel.Models.RoomModels
{
    public class CapacityRoom
    {
        public CapacityRoom()
        {
            _RoomCapacity = new HashSet<Room>();
        }
        public int IdCapacity { get; set; }
        public int GuestNumber { get; set; }
        public ICollection<Room> _RoomCapacity { get; set; }
    }
}

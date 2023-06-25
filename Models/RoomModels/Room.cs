namespace MegaHotel.Models.RoomModels
{
    public class Room
    {
        public int IDRoom { get; set; }
        public int RoomNumber { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int CapacityRoomId { get; set; }
        public int TypeRoomId { get; set; }
        public CapacityRoom _CapacityRoom { get; set; }
        public TypeRoom _TypeRoom { get; set; }
    }
}

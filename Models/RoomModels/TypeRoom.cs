namespace MegaHotel.Models.RoomModels
{
    public class TypeRoom
    {
        public TypeRoom()
        {
            _RoomType = new HashSet<Room>();
        }
        public int IdType { get; set; }
        public EnumsRoom RoomType { get; set; }
        public ICollection<Room> _RoomType { get; set; }
    }

    public enum EnumsRoom
    {
        Lux, Premium, PremiumLux, Basic
    }
}

using MegaHotel.Models.OrderModels;

namespace MegaHotel.Models.RoomModels
{
    public class CalendarRoom
    {
        public int IDCalendar { get; set; }
        public DateTime Data { get; set; } 
        public bool IsAvaible { get; set; }
        public int RoomCalendarId { get; set; }
        public int? CalendarOrderId { get; set; }
        public Room _RoomCalendar { get; set; }
        public Order _CalendarOrder { get; set; }
    }
}

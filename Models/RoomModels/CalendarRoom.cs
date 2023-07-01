namespace MegaHotel.Models.RoomModels
{
    public class CalendarRoom
    {
        public int IDCalendar { get; set; }
        public int Data { get; set; } 
        public bool IsAvaible { get; set; }
        public int RoomCalendarId { get; set; }
        public Room _RoomCalendar { get; set; }
    }
}

using MegaHotel.Models.RoomModels;
using MegaHotel.Models.UserModels;
using System.Globalization;

namespace MegaHotel.Models.OrderModels
{
    public class Order
    {
        public Order()
        {
            _calendarOrders = new HashSet<CalendarRoom>();
        }
        public int OrderID { get; set; }
        public int OrderUserId { get; set; }
        public User _orderUser { get; set; }
        public ICollection<CalendarRoom> _calendarOrders { get; set; }
    }
}

using MegaHotel.Models.OrderModels;
using Microsoft.SqlServer.Server;

namespace MegaHotel.Models.UserModels
{
    public class User
    {
        public User()
        {
            _userOrders = new HashSet<Order>();
        }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole _userRole { get; set; }
        public ICollection<Order> _userOrders { get; set; }
    }
}

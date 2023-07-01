using Microsoft.SqlServer.Server;

namespace MegaHotel.Models.UserModels
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole _userRole { get; set; }
    }
}

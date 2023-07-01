namespace MegaHotel.Models.UserModels
{
    public class UserRole
    {
        public UserRole()
        {
            _users = new HashSet<User>();
        }
        public int IdRole { get; set; }
        public EnumRole Role { get; set; }
        public ICollection<User> _users { get; set; }
    }
    public enum EnumRole
    { 
        RegularUser, Admin
    }
}

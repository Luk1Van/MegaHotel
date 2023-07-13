namespace MegaHotel.Models.UserModels
{
    public class UserRole
    {
        
        public int IdRole { get; set; }
        //public EnumRole Role { get; set; }
        public string Role { get; set; }
        public ICollection<User> _users { get; set; }
        public UserRole()
        {
            _users = new HashSet<User>();
        }
    }
    /*public enum EnumRole
    { 
        RegularUser, Admin
    }*/
}

using MegaHotel.Models.UserModels;

namespace MegaHotel.Services.IHotelServices
{
    public interface IUserService
    {
        public IEnumerable<User> CheckUser(string email, string password);
        public IEnumerable<User> CheckUserEmail(string email);
        public Task<User> AddUser(string email, string password);
    }
}

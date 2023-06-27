using MegaHotel.Services.HotelServices;
using MegaHotel.Services.IHotelServices;

namespace MegaHotel.DependencyInjection
{
    public static class HotelDependencyInjection
    {
        public static void AddMyServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}

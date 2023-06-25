using MegaHotel.DataBase;
using MegaHotel.Models.MessageModels;
using MegaHotel.Services.IHotelServices;

namespace MegaHotel.Services.HotelServices
{
    public class MessageService : IMessageService
    {
        private readonly HotelDbContext _hotelDbContext;

        public MessageService(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }
        public void AddMessage(Message message)
        {
            var previousMessage = from c in _hotelDbContext.Messages
                                  where c == message
                                  select c;

            if (previousMessage.Count() > 0)
            {
                string result = "This message already exists";
            }

            _hotelDbContext.Add(message);
            _hotelDbContext.SaveChanges();
        }
    }
}

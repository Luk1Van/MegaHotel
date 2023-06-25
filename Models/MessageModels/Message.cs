using System.ComponentModel.DataAnnotations;

namespace MegaHotel.Models.MessageModels
{
    public class Message
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string MessageText { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
    }
}

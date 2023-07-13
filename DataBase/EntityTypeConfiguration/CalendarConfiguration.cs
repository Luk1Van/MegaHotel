using MegaHotel.Models.RoomModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace MegaHotel.DataBase.EntityTypeConfiguration
{
    public class CalendarConfiguration : IEntityTypeConfiguration<CalendarRoom>
    {
        public void Configure(EntityTypeBuilder<CalendarRoom> builder)
        {
            builder.HasKey(c => c.IDCalendar);
            builder.HasIndex(c => c.IDCalendar).IsUnique();

            builder
                .HasOne(c => c._RoomCalendar)
                .WithMany(a => a._CalendarRoom)
                .HasForeignKey(k => k.RoomCalendarId);

            builder
                .HasOne(c => c._CalendarOrder)
                .WithMany(c => c._calendarOrders)
                .HasForeignKey(c => c.CalendarOrderId);
        }
    }
}

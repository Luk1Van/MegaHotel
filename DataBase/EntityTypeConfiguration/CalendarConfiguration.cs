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

            builder.HasData( new CalendarRoom { IDCalendar = 1, Data = 1, RoomCalendarId = 1, IsAvaible =true } );
            builder.HasData(new CalendarRoom { IDCalendar = 2, Data = 2, RoomCalendarId = 1, IsAvaible = true });
            builder.HasData(new CalendarRoom { IDCalendar = 3, Data = 3, RoomCalendarId = 1, IsAvaible = true });
        }
    }
}

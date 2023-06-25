using MegaHotel.Models.RoomModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MegaHotel.DataBase.EntityTypeConfiguration
{
    public class CapacityConfiguration : IEntityTypeConfiguration<CapacityRoom>
    {
        public void Configure(EntityTypeBuilder<CapacityRoom> builder)
        {
            builder.HasKey(c => c.IdCapacity);
            builder.HasIndex(c => c.IdCapacity).IsUnique();


            builder.HasData(new CapacityRoom { IdCapacity = 1, GuestNumber = 1 });
            builder.HasData(new CapacityRoom { IdCapacity = 2, GuestNumber = 2 });
            builder.HasData(new CapacityRoom { IdCapacity = 3, GuestNumber = 3 });
            builder.HasData(new CapacityRoom { IdCapacity = 4, GuestNumber = 6 });
        }
    }
}

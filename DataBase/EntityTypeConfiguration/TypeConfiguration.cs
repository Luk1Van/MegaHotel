using MegaHotel.Models.RoomModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;

namespace MegaHotel.DataBase.EntityTypeConfiguration
{
    public class TypeConfiguration : IEntityTypeConfiguration<TypeRoom>
    {
        public void Configure(EntityTypeBuilder<TypeRoom> builder)
        {
            builder.HasKey(c => c.IdType);
            builder.HasIndex(c => c.IdType).IsUnique();

            builder.HasData(new TypeRoom { IdType = 1, RoomType = EnumsRoom.Basic });
            builder.HasData(new TypeRoom { IdType = 2, RoomType = EnumsRoom.Premium });
            builder.HasData(new TypeRoom { IdType = 3, RoomType = EnumsRoom.Lux });
            builder.HasData(new TypeRoom { IdType = 4, RoomType = EnumsRoom.PremiumLux });

            builder
                .Property(g => g.RoomType)
                .HasConversion(new EnumToStringConverter<EnumsRoom>());
        }
    }
}

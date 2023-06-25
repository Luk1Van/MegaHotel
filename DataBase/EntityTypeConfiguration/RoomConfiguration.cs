using MegaHotel.Models.RoomModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MegaHotel.DataBase.EntityTypeConfiguration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.IDRoom);
            builder.HasIndex(x => x.IDRoom).IsUnique();

            builder
                .HasOne(c => c._CapacityRoom)
                .WithMany(a => a._RoomCapacity)
                .HasForeignKey(k => k.CapacityRoomId);



            builder.HasData(new Room
            {
                IDRoom = 1,
                RoomNumber = 20,
                CapacityRoomId = 2,
                Description = "Basic room for two person.",
                Price = 49.99,
                TypeRoomId = 1,
                ImageURL = "https://images.unsplash.com/photo-1618773928121-c32242e63f39?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80"
            });
            builder.HasData(new Room
            {
                IDRoom = 2,
                RoomNumber = 21,
                CapacityRoomId = 1,
                Description = "Basic room for one person.",
                Price = 35.99,
                TypeRoomId = 1,
                ImageURL = "https://images.unsplash.com/photo-1611892440504-42a792e24d32?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80"
            });

            builder.HasData(new Room
            {
                IDRoom = 3,
                RoomNumber = 30,
                CapacityRoomId = 3,
                Description = "Premium room for three person.",
                Price = 65.99,
                TypeRoomId = 2,
                ImageURL = "https://images.unsplash.com/photo-1591088398332-8a7791972843?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1074&q=80"
            });
            builder.HasData(new Room
            {
                IDRoom = 4,
                RoomNumber = 31,
                CapacityRoomId = 3,
                Description = "premium room for three person.",
                Price = 65.99,
                TypeRoomId = 2,
                ImageURL = "https://images.unsplash.com/photo-1590490360182-c33d57733427?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1074&q=80"
            });

            builder.HasData(new Room
            {
                IDRoom = 5,
                RoomNumber = 40,
                CapacityRoomId = 2,
                Description = "Lux room for two person.",
                Price = 99.99,
                TypeRoomId = 3,
                ImageURL = "https://images.unsplash.com/photo-1562438668-bcf0ca6578f0?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1460&q=80"
            });
            builder.HasData(new Room
            {
                IDRoom = 6,
                RoomNumber = 41,
                CapacityRoomId = 3,
                Description = "Lux room for three person.",
                Price = 129.99,
                TypeRoomId = 3,
                ImageURL = "https://images.unsplash.com/photo-1578683010236-d716f9a3f461?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80"
            });

            builder.HasData(new Room
            {
                IDRoom = 7,
                RoomNumber = 50,
                CapacityRoomId = 4,
                Description = "Premium-Lux for 6 person.",
                Price = 249.99,
                TypeRoomId = 4,
                ImageURL = "https://plus.unsplash.com/premium_photo-1661876306620-f2f2989f8f8b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1084&q=80"
            });
        }
    }
}

using MegaHotel.DataBase.EntityTypeConfiguration;
using MegaHotel.Models.MessageModels;
using MegaHotel.Models.RoomModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MegaHotel.DataBase
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CapacityRoom> CapacityRooms { get; set; }
        public DbSet<TypeRoom> TypeRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CapacityConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new TypeConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}

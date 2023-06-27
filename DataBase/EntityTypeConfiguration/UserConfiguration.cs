using MegaHotel.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaHotel.DataBase.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder.HasKey(c => c.UserId);
           builder.HasIndex(c => c.UserId).IsUnique();

            builder.HasData(new User { UserId = 1, Email = "capybara@gmail.com", Password = "happyCapy" });
            builder.HasData(new User { UserId = 2, Email = "monkey@gmail.com", Password = "happyMonkey" });
            builder.HasData(new User { UserId = 3, Email = "rat@gmail.com", Password = "happyRat" });
        }
    }
}

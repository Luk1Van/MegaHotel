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

           builder
                 .HasOne(c => c._userRole)
                 .WithMany(c => c._users)
                 .HasForeignKey(c => c.UserRoleId);

            builder.HasData(new User { UserId = 1, Email = "capybara@gmail.com", Password = "happyCapy", UserRoleId = 2 });
            builder.HasData(new User { UserId = 2, Email = "monkey@gmail.com", Password = "happyMonkey", UserRoleId = 1 });
            builder.HasData(new User { UserId = 3, Email = "rat@gmail.com", Password = "happyRat", UserRoleId = 1 });
        }
    }
}

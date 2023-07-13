using MegaHotel.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaHotel.DataBase.EntityTypeConfiguration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(c => c.IdRole);
            builder.HasIndex(c => c.IdRole).IsUnique();

            /*builder.HasData(new UserRole { IdRole = 1, Role = EnumRole.RegularUser});
            builder.HasData(new UserRole { IdRole = 2, Role = EnumRole.Admin });*/

            builder.HasData(new UserRole { IdRole = 1, Role = "regularUser" });
            builder.HasData(new UserRole { IdRole = 2, Role = "admin" });
        }
    }
}

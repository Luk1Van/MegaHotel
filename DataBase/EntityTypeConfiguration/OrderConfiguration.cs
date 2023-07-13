using MegaHotel.Models.MessageModels;
using MegaHotel.Models.OrderModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaHotel.DataBase.EntityTypeConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderID);
            builder.HasIndex(x => x.OrderID).IsUnique();

            builder.HasOne(x => x._orderUser)
                   .WithMany(x => x._userOrders)
                   .HasForeignKey(x => x.OrderUserId);
        }
    }
}

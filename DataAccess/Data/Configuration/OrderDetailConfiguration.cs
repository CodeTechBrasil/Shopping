using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class OrderDetailConfiguration : BaseDomainConfiguration<OrderDetail>
    {
        private static string _nameTable = DB.TABLE_ORDER_DETAIL;
        public OrderDetailConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.OrderHeaderId)
                .IsRequired();

            builder
               .Property(x => x.ProductId)
               .IsRequired();

            builder
                .Property(X => X.Sqft)
                .HasPrecision(8)
                .IsRequired();

            builder
                .Property(X => X.PricePerSqFt)
                .HasPrecision(18,2)
                .IsRequired();

            builder
                .HasOne(x => x.Product);

            builder
                .HasOne(x => x.OrderHeader)
                .WithMany(x => x.ListOrderDetail)
                .HasForeignKey(x => x.OrderHeaderId);
        }
    }
}

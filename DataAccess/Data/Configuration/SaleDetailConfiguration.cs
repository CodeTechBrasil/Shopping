using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class SaleDetailConfiguration : BaseDomainConfiguration<SaleDetail>
    {
        private static string _nameTable = DB.TABLE_SALE_DETAIL;
        public SaleDetailConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.SaleHeaderId)
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
                .HasOne(x => x.SaleHeader)
                .WithMany(x => x.ListSaleDetail)
                .HasForeignKey(x => x.SaleHeaderId);
        }
    }
}

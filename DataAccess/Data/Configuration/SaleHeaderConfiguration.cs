using Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class SaleHeaderConfiguration : BaseDomainConfiguration<SaleHeader>
    {

        private static string _nameTable = DB.TABLE_SALE_HEADER;
        public SaleHeaderConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<SaleHeader> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.OrderDate)
                .IsRequired();

            builder
                .Property(x => x.ShippingDate)
                .IsRequired();

            builder
                .Property(x => x.FinalOrderTotal)
                .HasPrecision(16,2)
                .IsRequired();

            builder
                .Property(x => x.OrderStatus)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.PaymentDate)
                .IsRequired();

            builder
                .Property(x => x.TransactionId)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(x => x.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder
               .Property(x => x.StreetAddress)
               .HasMaxLength(150)
               .IsRequired();

            builder
               .Property(x => x.City)
               .HasMaxLength(80)
               .IsRequired();

            builder
               .Property(x => x.State)
               .HasMaxLength(80)
               .IsRequired();

            builder
               .Property(x => x.PostalCode)
               .HasMaxLength(20)
               .IsRequired();

            builder
               .Property(x => x.FullName)
               .HasMaxLength(50)
               .IsRequired();

            builder
               .Property(x => x.Email)
               .HasMaxLength(150)
               .IsRequired();
        }
    }
}

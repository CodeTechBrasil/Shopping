using Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess.Data.Configuration
{
    public class ProductConfiguration : BaseDomainConfiguration<Product>
    {

        private static string _nameTable = DB.TABLE_PRODUCT;
        public ProductConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.ShortDesc)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Price)
                .HasPrecision(10,5)
                .IsRequired();

            builder
                .Property(x => x.Image)
                .IsRequired();

            builder
                .Property(x => x.Category)
                .IsRequired();

            builder
                .Property(x => x.ApplicationTypeId)
                .IsRequired();

        }
    }
}

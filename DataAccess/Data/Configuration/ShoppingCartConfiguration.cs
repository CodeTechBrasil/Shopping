using Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class ShoppingCartConfiguration : BaseDomainConfiguration<ShoppingCart>
    {
        private static string _nameTable = DB.TABLE_SHOPPING_CART;
        public ShoppingCartConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.ProductId)
                .IsRequired();

            builder
               .Property(x => x.SqFt)
               .HasPrecision(10);

            //.HasColumnName("Name")
            //.HasColumnType("nvarchar(max)");
            //builder.Ignore(x => x.DisplayOrder);
        }

    }
}

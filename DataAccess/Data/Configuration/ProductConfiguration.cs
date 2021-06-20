using Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
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
                .HasPrecision(18,2)
                .IsRequired();

            builder
                .Property(x => x.Image)
                .IsRequired();

            builder
                .Property(x => x.CategoryId)
                .HasPrecision(8)
                .IsRequired();

            builder
                .Property(x => x.ApplicationTypeId)
                .HasPrecision(8)
                .IsRequired();

            builder
                .Ignore(x => x.TempSqFt);

            //RELACIONAMENTO 1 PARA MUITO - NA CLASSE PAI[CATEGORY] TEM QUE TER UMA LISTA DE PRODUTO E NA CLASSE FILHA [PRODUCT] TEM QUE TER UMA INSTÂNCIA DA CATEGORY

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.ListProduct)
                .HasForeignKey(x => x.CategoryId);

            //RELACIONAMENTO 1 PARA MUITO - NA CLASSE PAI[ApplicationType] TEM QUE TER UMA LISTA DE PRODUTO E NA CLASSE FILHA [PRODUCT] TEM QUE TER UMA INSTÂNCIA DA ApplicationType

            builder
               .HasOne(x => x.ApplicationType)
               .WithMany(x => x.ListProduct)
               .HasForeignKey(x => x.ApplicationTypeId);
        }
    }
}

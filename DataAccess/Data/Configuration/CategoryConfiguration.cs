using Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class CategoryConfiguration : BaseDomainConfiguration<Category>
    {
        private static string _nameTable = DB.TABLE_CATEGORY;
        public CategoryConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
               .Property(x => x.DisplayOrder)
               .HasPrecision(10);
        }
    }
}

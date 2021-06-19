using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class InquiryDetailConfiguration : BaseDomainConfiguration<InquiryDetail>
    {
        private static string _nameTable = DB.TABLE_CATEGORY;
        public InquiryDetailConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<InquiryDetail> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
               .Property(x => x.DisplayOrder)
               .HasPrecision(10);

            //.HasColumnName("Name")
            //.HasColumnType("nvarchar(max)");
            //builder.Ignore(x => x.DisplayOrder);
        }

    }
}

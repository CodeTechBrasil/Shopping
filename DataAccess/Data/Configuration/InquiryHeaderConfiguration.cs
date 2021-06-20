using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class InquiryHeaderConfiguration : BaseDomainConfiguration<InquiryHeader>
    {
        private static string _nameTable = DB.TABLE_INQUIRY_HEADER;
        public InquiryHeaderConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<InquiryHeader> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.InquiryDate)
                .IsRequired();

            builder
               .Property(x => x.PhoneNumber)
               .HasMaxLength(20)
               .IsRequired();

            builder
              .Property(x => x.FullName)
              .HasMaxLength(50)
              .IsRequired();

            builder
              .Property(x => x.Email)
              .HasMaxLength(50)
              .IsRequired();

            //.HasColumnName("Name")
            //.HasColumnType("nvarchar(max)");
            //builder.Ignore(x => x.DisplayOrder);
        }

    }
}

using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class OrderHeaderConfiguration : BaseDomainConfiguration<OrderHeader>
    {
        private static string _nameTable = DB.TABLE_ORDER_HEADER;
        public OrderHeaderConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<OrderHeader> builder)
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
              .HasMaxLength(150)
              .IsRequired();

            builder
              .Property(x => x.Email)
              .HasMaxLength(150)
              .IsRequired();

            //.HasColumnName("Name")
            //.HasColumnType("nvarchar(max)");
            //builder.Ignore(x => x.DisplayOrder);
        }

    }
}

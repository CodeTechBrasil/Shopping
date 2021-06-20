using Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class InquiryDetailConfiguration : BaseDomainConfiguration<InquiryDetail>
    {
        private static string _nameTable = DB.TABLE_INQUIRY_DETAIL;
        public InquiryDetailConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<InquiryDetail> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.InquiryHeaderId)
                .IsRequired();

            builder
               .Property(x => x.ProductId)
               .IsRequired();
        }
    }
}

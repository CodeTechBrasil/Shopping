using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configuration
{
    public class ProductConfiguration : BaseDomainConfiguration<Product>
    {

        private static string _nameTable = DB.TABLE_PRODUCT;
        public ProductConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

        }
    }
}

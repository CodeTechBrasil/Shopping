using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class SubCategoryConfiguration : BaseDomainConfiguration<SubCategory>
    {
        private static string _nameTable = DB.TABLE_SUB_CATEGORY;
        public SubCategoryConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            base.Configure(builder);

            //TODO - Apesar de haverem as Annotations dizendo que o campo é requerido
            //decidi colocar a propriedade aqui também, para o caso de o projeto caminhar
            //para a remoçãos das Annotations

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }

    }
}

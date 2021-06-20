using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class ApplicationTypeConfiguration : BaseDomainConfiguration<ApplicationType>
    {
        private static string _nameTable = DB.TABLE_APPLICATION_TYPE;
        public ApplicationTypeConfiguration() : base(_nameTable) { }

        public override void Configure(EntityTypeBuilder<ApplicationType> builder)
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

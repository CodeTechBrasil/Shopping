using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DataAccess
{
    public class BaseDomainConfiguration<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseDomain
    {
        private readonly string _tableName;

        //PASSA O NOME DA TABELA POR PARÂMETRO
        public BaseDomainConfiguration(string tableName = "")
        {
            _tableName = tableName;
        }

        //CRIA UMA CLASSE GENÉRICA DE MAPEAMENTO PARA OS CAMPOS QUE SE REPETEM EM TODOS OS MAPEAMENTOS.
        public virtual void Configure(EntityTypeBuilder<TDomain> builder)
        {
            //VERIFICA SE O NOME DA TABELA FOI INFORMADO
            if (!string.IsNullOrEmpty(_tableName))
                builder.ToTable(_tableName);

            //PROPRIEDADES QUE SÃO FREQUENTES EM TODOS OS MAPEAMENTOS.
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)      // PROPRIEDADE QUE SERÁ VINCULADA COM A CRIAÇÃO
                .HasColumnName("Id")            // INFORMA COMO SERÁ O NOME DA COLUNA.
                //.HasColumnType("int")         // INFORMA O TIPO QUE SERÁ CRIADO, CASO NÃO INFORMADO O ENTITY VAI PEGAR O CAMPO DECLARADO NA VARIÁVEL.
                .ValueGeneratedOnAdd();         // INFORMA QUE O CAMPO ID SERÁ AUTO INCREMENTO.

        }
    }
}

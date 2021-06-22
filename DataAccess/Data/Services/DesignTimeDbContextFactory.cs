using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        //ESTÁ CLASSE SERVE PARA GERAR AS MIGRAÇÕES EM QUALQUER LUGAR DA SOLUÇÃO.
        public ApplicationDbContext  CreateDbContext(string[] args)
        {
            //PEGA A VARIAVEL DE AMBIENTE DO ASP.NET CORE [PRODUÇÃO, DESENVOLVIMENTO, ETC..].
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //PEGA O NOME DO ARQUIVO DE ACORDO COM O AMBIENTE SELECIONADO.
            var fileName = Directory.GetCurrentDirectory() +
                    $"/../Shop/appsettings.{environmentName}.json";

            //CARREGA O ARQUIVO DE CONFIGURAÇÃO.
            var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();

            //PEGA A CONEXÃO DE STRING DENTRO DO ARQUIVO DE CONFIGURAÇÃO SELECIONADO.
            var connectionString = configuration.GetConnectionString(DB.CONNECTION_STRING);

            //CRIA UMA INSTÂNCIA DBCONTEXT E CONFIGURA A CONEXÃO DE STRING.
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlServer(connectionString);

            //RETORNA O DBCONTEX CONFIGURADO.
            return new ApplicationDbContext(builder.Options);
        }
    }
}

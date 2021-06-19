using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            EnumDatabase enumDabase = EnumDatabase.SqlServer;
            switch (enumDabase)
            {
                case EnumDatabase.SqlServer:
                    var connSqlServer = "Server=127.0.0.1,1433;Database=Shop;User=sa;Password=a"; ;
                    optionsBuilder.UseSqlServer(connSqlServer);
                    break;
                case EnumDatabase.MySql:
                    break;
                case EnumDatabase.Postgres:
                    var connPostgres = string.Empty;
                    optionsBuilder.UseNpgsql(connPostgres);
                    break;
                case EnumDatabase.Oracle:
                    break;
                default:
                    break;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}

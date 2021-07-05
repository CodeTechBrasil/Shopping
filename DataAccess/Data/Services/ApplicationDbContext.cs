using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<SaleHeader> SaleHeader { get; set; }
        public DbSet<SaleDetail> SaleDetail { get; set; }

        public ApplicationDbContext()
        {
            //ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
            //ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //var connSqlServer = "Server=127.0.0.1,1433;Database=Shop;User=sa;Password=a"; ;
            //optionsBuilder.UseSqlServer(connSqlServer);

            //EnumDatabase enumDabase = EnumDatabase.SqlServer;
            //switch (enumDabase)
            //{
            //    case EnumDatabase.SqlServer:
            //var connSqlServer = "Server=127.0.0.1,1433;Database=Shop;User=sa;Password=a"; ;
            //optionsBuilder.UseSqlServer(connSqlServer);
            //        break;
            //    case EnumDatabase.MySql:
            //        break;
            //    case EnumDatabase.Postgres:
            //        var connPostgres = string.Empty;
            //        optionsBuilder.UseNpgsql(connPostgres);
            //        break;
            //    case EnumDatabase.Oracle:
            //        break;
            //    default:
            //        break;
            //}
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}

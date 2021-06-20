using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<InquiryHeader> InquiryHeader { get; set; }
        public DbSet<InquiryDetail> InquiryDetail { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //EnumDatabase enumDabase = EnumDatabase.SqlServer;
            //switch (enumDabase)
            //{
            //    case EnumDatabase.SqlServer:
            //        var connSqlServer = "Server=127.0.0.1,1433;Database=Shop;User=sa;Password=a"; ;
            //        optionsBuilder.UseSqlServer(connSqlServer);
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

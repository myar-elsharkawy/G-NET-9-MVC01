using Microsoft.EntityFrameworkCore;
using WebApp_MVC01.Configurations;
using WebApp_MVC01.Models;

namespace WebApp_MVC01.WebAppContexts
{
    public class AppDbContext : DbContext
    {
        // Connection String 
        // Supposed to be in appsettings.JSON
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   // optionsBuilder.UseSqlServer("Server = . ; Database = WebAppMVC01 ; Trusted_Connection = True ; TrustServerCertificate = True");
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfigure());
        }

        // DbSets
        public DbSet<Plan> Plans { get; set; }
    }
}

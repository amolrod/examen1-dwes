using Microsoft.EntityFrameworkCore;
using ProyectoExamen.Models;

namespace ProyectoExamen.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venta>()
                .ToTable("VENTA");
        }
    }
}

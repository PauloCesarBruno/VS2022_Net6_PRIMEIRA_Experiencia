using Microsoft.EntityFrameworkCore;

namespace Brinquedos_NET6.Models.Data
{
    public class DataContext : DbContext
    {
        public DbSet <Brinquedo> Brinquedos { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brinquedo>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18, 2)");
        }
    }                  
}

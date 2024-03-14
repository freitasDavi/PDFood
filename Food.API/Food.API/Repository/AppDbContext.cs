using Food.API.Models.Files;
using Food.API.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Food.API.Repository
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<FileUpload> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(k => k.Id);
            });

            modelBuilder.Entity<FileUpload>(e =>
            {
                e.HasKey(k => k.Id);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

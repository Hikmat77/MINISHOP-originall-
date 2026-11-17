using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(x => x.Price).HasColumnName("price").HasColumnType("numeric(18,2)");
            entity.Property(x => x.CategoryId).HasColumnName("category_id");
            entity.HasOne<Category>()
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}

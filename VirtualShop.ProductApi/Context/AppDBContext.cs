using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Context;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Category>().HasKey(c => c.Id);
        mb.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        mb.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(c => c.Category)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        mb.Entity<Category>().HasData(
        new Category
        {
            Id = 1,
            Name = "Acessórios"
        },
        new Category 
        {
            Id = 2,
            Name = "Material Escolar"
        }
        );

        mb.Entity<Product>().HasKey(p => p.Id);
        mb.Entity<Product>()
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        mb.Entity<Product>()
            .Property(p => p.Description)
            .HasMaxLength(255)
            .IsRequired();

        mb.Entity<Product>()
            .Property(p => p.ImageURL)
            .HasMaxLength(255)
            .IsRequired();

        mb.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(12,2)
            .IsRequired();

    }
}

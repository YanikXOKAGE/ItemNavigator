using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Configuration;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Items> Items { get; set; }
    public DbSet<Catalogs> Catalogs { get; set; }

    public DbSet<CatalogItemRelations> CatalogItemRelations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Items>().HasKey(item => item.item_id);
        modelBuilder.Entity<Catalogs>().HasKey(catalog => catalog.catalog_id);
        modelBuilder.Entity<CatalogItemRelations>()
            .HasKey(cir => new { cir.item_id, cir.catalog_id });

        modelBuilder.Entity<CatalogItemRelations>()
            .HasOne(cir => cir.Items)
            .WithMany(item => item.CatalogItemRelation)
            .HasForeignKey(cir => cir.item_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CatalogItemRelations>()
            .HasOne(cir => cir.Catalogs)
            .WithMany(catalog => catalog.CatalogItemRelations)
            .HasForeignKey(cir => cir.catalog_id)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
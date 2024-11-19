using Avito.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avito.DataAccess;

public class AvitoDbContext : DbContext
{
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<ItemForSelling> ItemsForSelling { get; set; }
    public DbSet<PickUpPoint> PickUpPoints { get; set; }
    
    public AvitoDbContext(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Seller>().HasKey(x => x.Id);
        modelBuilder.Entity<Administrator>().HasKey(x => x.Id);
        modelBuilder.Entity<ItemForSelling>().HasKey(x => x.Id);
        modelBuilder.Entity<PickUpPoint>().HasKey(x => x.Id);
        modelBuilder.Entity<Seller>().HasMany(x => x.Items).WithMany(x => x.Sellers);
        
        modelBuilder.Entity<ItemForSelling>().HasOne(x => x.PickUpPoint).WithMany(x => x.Items).HasForeignKey(x => x.PickUpPointId);
        
    }
}
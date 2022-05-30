using AzureBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureBackend.Data;

// TODO: Add to Program.cs when ready to init a DB.
// TODO: Change the constructor of OverlayController and CapabilitiesController to the commented one.
public class DataContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Overlay> Overlays{ get; set; }
    public DbSet<OverlayDataElement> OverlayDataElements { get; set; }

    public string DbPath { get; } = ".";


    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Filename={DbPath}/data.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Overlay>()
            .HasMany(p => p.Data)
            .WithOne();
    }
}

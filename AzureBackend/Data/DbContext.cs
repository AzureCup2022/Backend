using AzureBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureBackend.Data;

// TODO: Add to Program.cs when ready to init a DB.
// TODO: Change the constructor of OverlayController and CapabilitiesController to the commented one.
public class DatabaseContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Overlay> Overlays { get; set; }

    public string DbPath { get; } = ".";


    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Filename={DbPath}/data.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}

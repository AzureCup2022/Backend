using Microsoft.EntityFrameworkCore;

namespace AzureBackend.Data;

// TODO: Add to Program.cs when ready to init a DB.
// TODO: Change the constructor of OverlayController and CapabilitiesController to the commented one.
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}

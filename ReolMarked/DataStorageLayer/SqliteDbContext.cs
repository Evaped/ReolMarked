using Microsoft.EntityFrameworkCore;
using ReolMarked.DomainLayer;

namespace ReolMarked.DataStorageLayer;

public class SqliteDbContext: DbContext
{
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<Renter> Renters { get; set; }
    public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
    public DbSet<ShelfLeaseAgreement> ShelfLeaseAgreement { get; set; }
    public string DbPath { get; }

    public SqliteDbContext(DbContextOptions options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "reol.db");
    }
    

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
        
    }
    
    
        
}
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using ReolMarked.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.DataStorageLayer;
public class DataBaseContext : DbContext
{
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<Renter> Renters { get; set; }
    public DbSet<LeaseAgreement> LeaseAgreements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseServerInstance"].ConnectionString; ;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

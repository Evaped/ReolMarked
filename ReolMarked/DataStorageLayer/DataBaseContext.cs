using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using ReolMarked.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ReolMarked.DataStorageLayer;

public class DataBaseContext : DbContext
{
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<Renter> Renters { get; set; }
    public DbSet<LeaseAgreement> LeaseAgreements { get; set; }

    protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = configuration.GetConnectionString("DatabaseServerInstance");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}


using Microsoft.EntityFrameworkCore;
using ReolMarked.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.DataStorageLayer
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<LeaseAgreement> LeaseAgreements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=10.56.8.36; Database=P3_DB_2023_35; User Id=DB_F23_USER_35; Password=OPENDB_35;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

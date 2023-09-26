using Microsoft.EntityFrameworkCore;
using ReolMarked;
using ReolMarked.DataStorageLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    public class RenterRepositoryShould
    {
        private readonly SqliteDbContext _dbContext;

        public RenterRepositoryShould()
        {
            var dbOptions = new DbContextOptionsBuilder().UseInMemoryDatabase(
            Guid.NewGuid().ToString());

            _dbContext = new SqliteDbContext(dbOptions.Options);
        }

        [Fact]
        public async Task AddRenter()
        {
            var repo = new RenterRepository(_dbContext);
            var renter = new Renter()
            {
                FirstName = "hans",
                LastName = "børge",
                Email = "hans-børge@hot.dk",
                PhoneNumber = "1234567890"
            };

           await repo.CreateAsync(renter);
           var renters = await repo.GetAsync();

            Assert.Single(renters);

        }
        [Fact]
        public async Task UpdateRenter()
        {
            var repo = new RenterRepository(_dbContext);
            var renter = new Renter()
            {
                FirstName = "hans",
                LastName = "børge",
                Email = "hans-børge@hot.dk",
                PhoneNumber = "1234567890"
            };

            await repo.CreateAsync(renter);

            renter.LastName = "Hansen";

            await repo.UpdateAsync(renter);

            Assert.Equal("Hansen", renter.LastName);
        }
        [Fact]
        public async Task DeleteRenter()
        {
            var repo = new RenterRepository(_dbContext);
            var renter = new Renter()
            {
                FirstName = "hans",
                LastName = "børge",
                Email = "hans-børge@hot.dk",
                PhoneNumber = "1234567890"
            };

            await repo.CreateAsync(renter);
            await repo.DeleteAsync(renter);

            var renters = await repo.GetAsync();

            Assert.Equal(0, renters.Count());
        }
    }
}

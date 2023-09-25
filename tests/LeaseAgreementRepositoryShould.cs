using Microsoft.EntityFrameworkCore;
using ReolMarked.DataStorageLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    
    public class LeaseAgreementRepositoryShould
    {
        private readonly SqliteDbContext _dbContext;

        public LeaseAgreementRepositoryShould()
        {
            var dbOptions = new DbContextOptionsBuilder().UseInMemoryDatabase(
            Guid.NewGuid().ToString());

            _dbContext = new SqliteDbContext(dbOptions.Options);
        }

        [Fact]
        public async Task
        
    }
}

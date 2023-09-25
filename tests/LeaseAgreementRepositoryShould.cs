using Microsoft.EntityFrameworkCore;
using ReolMarked;
using ReolMarked.DataStorageLayer;
using ReolMarked.DomainLayer;
using ReolMarked.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public async Task AddLeaseAgreement()
        {
            var repoRenter = new RenterRepository(_dbContext);
            var repo = new LeaseAgreementRepository(_dbContext);
            var LeaseDTO = new LeaseAgreementDTO()
            {
                StartDate = DateTime.Now,
                RentDuration = 10,
                Price = 500,
                ShelvesCount = 1,
                Email = "email@benni.com",
            };
            
            Renter renter = await repoRenter.GetByEmailAsync(LeaseDTO.Email);

            if (renter == null)
            {
                renter = new Renter()
                {
                    Email = LeaseDTO.Email
                };
                await repoRenter.CreateAsync(renter);
            }
            
            var leaseAgreement = new LeaseAgreement()
            {
                StartDate = LeaseDTO.StartDate,
                RentDuration = LeaseDTO.RentDuration,
                Price = LeaseDTO.Price,
                ShelvesCount = LeaseDTO.ShelvesCount,
                RenterId = renter.Id
            };
            await repo.CreateAsync(leaseAgreement);

            var leases = await repo.GetAsync();
            Assert.Single(leases); 
        }

        //[Fact]
        //public Async Task UpdateLeaseAgreement()
        //{

        //}
        
    }
}

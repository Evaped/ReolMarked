using ReolMarked.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReolMarked.DataStorageLayer;
public class LeaseAgreementRepository : GenericRepository<LeaseAgreement>
{
    public LeaseAgreementRepository(SqliteDbContext dbContext) : base(dbContext)
    {
        
    }
}

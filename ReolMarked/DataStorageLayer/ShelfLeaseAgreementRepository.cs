using ReolMarked.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReolMarked.DataStorageLayer;
public class ShelfLeaseAgreementRepository : GenericRepository<ShelfLeaseAgreement>
{
    public ShelfLeaseAgreementRepository(DbContext dbContext) : base(dbContext)
    {

    }
}

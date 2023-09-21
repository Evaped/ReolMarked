using ReolMarked.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.DataStorageLayer;
public class ShelfLeaseAgreementRepository : GenericRepository<ShelfLeaseAgreement>
{
    public ShelfLeaseAgreementRepository(DataBaseContext dbContext) : base(dbContext)
    {

    }
}

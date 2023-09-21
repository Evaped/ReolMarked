using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.DataStorageLayer;
public class RenterRepository : GenericRepository<Renter>
{
    public RenterRepository(DataBaseContext dbContext) : base(dbContext)
    {
        
    }
}

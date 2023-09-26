using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReolMarked.DataStorageLayer;
public class RenterRepository : GenericRepository<Renter>
{
    public RenterRepository(SqliteDbContext dbContext) : base(dbContext)
    {
        
    }
    public async Task<Renter> GetByEmailAsync(string email)
    {
        return await _dbContext.Set<Renter>().FirstOrDefaultAsync(x => x.Email.Equals(email));
    }
}

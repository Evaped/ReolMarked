using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.DataStorageLayer;
public class ShelfRepository : GenericRepository<Shelf>
{
    public ShelfRepository(SqliteDbContext dbContext) : base(dbContext)
    {
        
    }
    public async Task<Shelf> GetShelfByLocationName(string locationName)
    {
        return await _dbContext.Set<Shelf>().FirstOrDefaultAsync(q => q.Location == locationName);
    }
    
    public async Task<Shelf> GetByDateTime(DateTime dateTime)
    {
        return await _dbContext.Set<Shelf>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.BookingEndDate == null || q.BookingEndDate <= dateTime);
    }
}

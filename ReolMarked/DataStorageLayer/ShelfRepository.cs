using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.DataStorageLayer;
public class ShelfRepository : GenericRepository<Shelf>
{
    public ShelfRepository(DbContext dbContext) : base(dbContext)
    {

    }
    public async Task<Shelf> GetShelfByLocationName(string locationName)
}

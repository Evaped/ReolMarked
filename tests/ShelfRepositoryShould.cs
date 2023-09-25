

using Microsoft.EntityFrameworkCore;
using ReolMarked;
using ReolMarked.DataStorageLayer;

namespace tests;

public class ShelfRepositoryShould
{
    private readonly SqliteDbContext _dbContext;

    public ShelfRepositoryShould()
    {
        var dbOptions = new DbContextOptionsBuilder().UseInMemoryDatabase(
            Guid.NewGuid().ToString());

        _dbContext = new SqliteDbContext(dbOptions.Options);

    }

    [Fact]
    public async Task AddShelf()
    {
        var repo = new ShelfRepository(_dbContext);
        var shelf = new Shelf()
        {
            Location = "location",
            shelfType = ShelfType.withoutGlass,
        };


        await repo.CreateAsync(shelf);

        var shelves = await repo.GetAsync();
        Assert.Single(shelves);
    }
}


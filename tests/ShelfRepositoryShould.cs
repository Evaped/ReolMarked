

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

    [Fact]
    public async Task UpdateShelf()
    {
        var repo = new ShelfRepository(_dbContext);
        var shelf1 = new Shelf()
        {
            Location = "1234",
            shelfType = ShelfType.withoutGlass,
        };
        await repo.CreateAsync(shelf1);

        shelf1.Location = "r2r3";
        await repo.UpdateAsync(shelf1);

        var response = await repo.GetShelfByLocationName(shelf1.Location);

        Assert.Equal("r2r3", response.Location);
    }

    [Fact]
    public async Task DeleteShelf()
    {
        var repo = new ShelfRepository(_dbContext);
        var shelf2 = new Shelf()
        {
            Location = "r1r1",
            shelfType = ShelfType.withGlass
        };
        await repo.CreateAsync(shelf2);

        await repo.DeleteAsync(shelf2);

        var shelves = await repo.GetAsync();
        Assert.Equal(0 , shelves.Count());

    }
    [Fact]
    public
}


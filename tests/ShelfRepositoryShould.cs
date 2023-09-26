

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
            ShelfType = ShelfType.withoutGlass,
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
            ShelfType = ShelfType.withoutGlass,
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
            ShelfType = ShelfType.withGlass
        };
        await repo.CreateAsync(shelf2);

        await repo.DeleteAsync(shelf2);

        var shelves = await repo.GetAsync();
        Assert.Equal(0 , shelves.Count());

    }
    [Fact]
    public async Task GetShelfById()
    {
        var repo = new ShelfRepository(_dbContext);
        var shelf = new Shelf()
        {
            Location = "r1r1",
            ShelfType = ShelfType.withGlass
        };
        await repo.CreateAsync(shelf);

        var response = await repo.GetByIdAsync(shelf.Id);

        Assert.Equal(shelf.Location, response.Location);
    }
    [Fact]
    public async Task GetShelfList()
    {
        var repo = new ShelfRepository(_dbContext);
        var shelf = new Shelf()
        {
            Location = "r1r1",
            ShelfType = ShelfType.withGlass
        };
        await repo.CreateAsync(shelf);
        var shelf1 = new Shelf()
        {
            Location = "r1r1",
            ShelfType = ShelfType.withGlass
        };
        await repo.CreateAsync(shelf1);
        var shelf2 = new Shelf()
        {
            Location = "r1r1",
            ShelfType = ShelfType.withGlass
        };
        await repo.CreateAsync(shelf2);

        var response = await repo.GetAsync();

        Assert.Equal(3, response.Count());
    }

    [Fact]

    public async Task IsShelfBooked()
    {
        
       //TODO 
       var dateTime = DateTime.Now;
       var repo = new ShelfRepository(_dbContext);
       var shelf = new Shelf()
       {
           Location = "r1r2",
           ShelfType = ShelfType.withGlass,
           BookingEndDate = new DateTime(2028, 4, 10)
           
       };
       await repo.CreateAsync(shelf);
       var shelf1 = new Shelf()
       {
           Location = "r1r1",
           ShelfType = ShelfType.withGlass
       };
       
       await repo.CreateAsync(shelf1);
       var shelf2 = new Shelf()
       {
           Location = "r1r3",
           ShelfType = ShelfType.withGlass,
           BookingEndDate = new DateTime(2022, 4, 10)
       };
       await repo.CreateAsync(shelf2);
       

       var res = await repo.GetByDateTime(dateTime);
       
       Assert.Equal(shelf1.Location, res.Location);
    }
}


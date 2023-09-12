using Microsoft.AspNetCore.Mvc;
using ReolMarked;
using ReolMarked.DataStorageLayer;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class ShelfController : ControllerBase
{
    private readonly ShelfRepository _shelfRepository;

    public ShelfController(ShelfRepository shelfRepository)
    {
        _shelfRepository = shelfRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetShelves()
    {
        var shelves = await _shelfRepository.GetAsync();
        return Ok(shelves);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShelfById(int id)
    {
        var shelf = await _shelfRepository.GetbyIdAsync(id);
        if (shelf == null)
        {
            return NotFound();
        }
        return Ok(shelf);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShelf([FromBody] Shelf shelf)
    {
        if (shelf == null)
        {
            return BadRequest();
        }

        await _shelfRepository.CreateAsync(shelf);
        return CreatedAtAction("GetShelfById", new { id = shelf.Id }, shelf);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShelf(int id, [FromBody] Shelf updatedShelf)
    {
        if (updatedShelf == null || id != updatedShelf.Id)
        {
            return BadRequest();
        }

        var existingShelf = await _shelfRepository.GetbyIdAsync(id);
        if (existingShelf == null)
        {
            return NotFound();
        }

        existingShelf.Id = updatedShelf.Id;
        existingShelf.Location = updatedShelf.Location;
        existingShelf.shelfType = updatedShelf.shelfType;

        await _shelfRepository.UpdateAsync(existingShelf);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShelf(int id)
    {
        var shelf = await _shelfRepository.GetbyIdAsync(id);
        if (shelf == null)
        {
            return NotFound();
        }

        await _shelfRepository.DeleteAsync(shelf);
        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using ReolMarked.DataStorageLayer;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShelfController : ControllerBase
    {
        private readonly ShelfRepository _shelfRepository;

        public ShelfController(ShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }

        [HttpGet(Name = "Shelf")]

        public async Task<IActionResult> GetShelves()
        {
            var shelves = await _shelfRepository.GetAsync();
            return Ok(shelves);
        }
        /*
        public async Task<IActionResult> GetShelfById(int id)
        {
            var shelf = await _shelfRepository.GetByIdAsync(id);
            if (shelf == null)
            {
                return NotFound();
            }
            return Ok(shelf);
        }
        */
    }
}

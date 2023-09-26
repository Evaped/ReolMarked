using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReolMarked.DataStorageLayer;
using ReolMarked.DTOs;

namespace ReolMarked.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly ShelfRepository _repository;

        public ShelfController(ShelfRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Shelf
        [HttpGet]
        public async Task<IEnumerable<Shelf>> Get()
        {
            return await _repository.GetAsync();
        }

        // GET: api/Shelf/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shelf
        [HttpPost]
        public async Task<int> Post(ShelfDTO shelfDto)
        {
            //TODO tilføj en shelfDTO
            
            var shelf = new Shelf
            {
                Location = shelfDto.Location,
                ShelfType = shelfDto.ShelfType
            };
    
            await  _repository.CreateAsync(shelf);
            return shelf.Id;
        }

        // PUT: api/Shelf/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Shelf/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

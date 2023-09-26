using Microsoft.AspNetCore.Mvc;
using ReolMarked;
using ReolMarked.DataStorageLayer;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class RenterController : ControllerBase
{
    private readonly RenterRepository _renterRepository;

    public RenterController(RenterRepository renterRepository)
    {
        _renterRepository = renterRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetRenters()
    {
        var renters = await _renterRepository.GetAsync();
        return Ok(renters);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRenterById(int id)
    {
        var renter = await _renterRepository.GetByIdAsync(id);
        if (renter == null)
        {
            return NotFound();
        }
        return Ok(renter);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRenter([FromBody] Renter renter)
    {
        if (renter == null)
        {
            return BadRequest();
        }

        await _renterRepository.CreateAsync(renter);
        return CreatedAtAction("GetRenterById", new { id = renter.Id }, renter);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRenter(int id, [FromBody] Renter updatedRenter)
    {
        if (updatedRenter == null || id != updatedRenter.Id)
        {
            return BadRequest();
        }

        var existingRenter = await _renterRepository.GetByIdAsync(id);
        if (existingRenter == null)
        {
            return NotFound();
        }

        existingRenter.Id = updatedRenter.Id;
        existingRenter.FirstName = updatedRenter.FirstName;
        existingRenter.LastName = updatedRenter.LastName;
        existingRenter.Email = updatedRenter.Email;
        existingRenter.PhoneNumber = updatedRenter.PhoneNumber;

        await _renterRepository.UpdateAsync(existingRenter);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRenter(int id)
    {
        var renter = await _renterRepository.GetByIdAsync(id);
        if (renter == null)
        {
            return NotFound();
        }

        await _renterRepository.DeleteAsync(renter);
        return NoContent();
    }
}

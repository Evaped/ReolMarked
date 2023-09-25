using Microsoft.AspNetCore.Mvc;
using ReolMarked;
using ReolMarked.DataStorageLayer;
using ReolMarked.DomainLayer;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class LeaseAgreementController : ControllerBase
{
    private readonly LeaseAgreementRepository _leaseAgreementRepository;

    public LeaseAgreementController(LeaseAgreementRepository leaseAgreementRepository)
    {
        _leaseAgreementRepository = leaseAgreementRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetLeaseAgreements()
    {
        var leaseAgreements = await _leaseAgreementRepository.GetAsync();
        return Ok(leaseAgreements);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRenterById(int id)
    {
        var leaseAgreement = await _leaseAgreementRepository.GetByIdAsync(id);
        if (leaseAgreement == null)
        {
            return NotFound();
        }
        return Ok(leaseAgreement);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLeaseAgreement([FromBody] LeaseAgreement leaseAgreement)
    {
        if (leaseAgreement == null)
        {
            return BadRequest();
        }

        await _leaseAgreementRepository.CreateAsync(leaseAgreement);
        return CreatedAtAction("GetLeaseAgreementrById", new { id = leaseAgreement.Id }, leaseAgreement);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLeaseAgreement(int id, [FromBody] LeaseAgreement updatedLeaseAgreement)
    {
        if (updatedLeaseAgreement == null || id != updatedLeaseAgreement.Id)
        {
            return BadRequest();
        }

        var existingLeaseAgreement = await _leaseAgreementRepository.GetByIdAsync(id);
        if (existingLeaseAgreement == null)
        {
            return NotFound();
        }

        existingLeaseAgreement.Id = updatedLeaseAgreement.Id;
        existingLeaseAgreement.StartDate = updatedLeaseAgreement.StartDate;
        existingLeaseAgreement.RentDuration = updatedLeaseAgreement.RentDuration;
        existingLeaseAgreement.IsPaid = updatedLeaseAgreement.IsPaid;
        existingLeaseAgreement.Price = updatedLeaseAgreement.Price;
        existingLeaseAgreement.DateCreated = updatedLeaseAgreement.DateCreated;

        await _leaseAgreementRepository.UpdateAsync(existingLeaseAgreement);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeaseAgreement(int id)
    {
        var renter = await _leaseAgreementRepository.GetByIdAsync(id);
        if (renter == null)
        {
            return NotFound();
        }

        await _leaseAgreementRepository.DeleteAsync(renter);
        return NoContent();
    }
}

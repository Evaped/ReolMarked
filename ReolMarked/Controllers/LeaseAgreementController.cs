using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ReolMarked.DataStorageLayer;
using ReolMarked.DomainLayer;
using ReolMarked.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaseAgreementController : ControllerBase
{
    private readonly ShelfRepository _shelfRepository;
    private readonly ShelfLeaseAgreementRepository _shelfLeaseAgreementRepository;
    private readonly LeaseAgreementRepository _leaseAgreementRepository;
    private readonly RenterRepository _renterRepository;
    public LeaseAgreementController(LeaseAgreementRepository leaseAgreementRepository, ShelfRepository shelfRepository, ShelfLeaseAgreementRepository shelfLeaseAgreementRepository, RenterRepository renterRepository)
    {
        _leaseAgreementRepository = leaseAgreementRepository;
        _shelfRepository = shelfRepository;
        _shelfLeaseAgreementRepository = shelfLeaseAgreementRepository;
        _renterRepository = renterRepository;
    }


    // POST: api/LeaseAgreement
    [HttpPost]
    public async Task<int> Post(LeaseAgreementDTO leaseAgreementDTO)
    {
        var shelf = await _shelfRepository.GetByDateTime(leaseAgreementDTO.StartDate);
        var renter = await _renterRepository.GetByEmailAsync(leaseAgreementDTO.Email);

        if (renter == null)
        {
            renter = new Renter()
            {
                Email = leaseAgreementDTO.Email
            };
            await _renterRepository.CreateAsync(renter);
        }
        var leaseAgreement = new LeaseAgreement()
        {
            StartDate = leaseAgreementDTO.StartDate,
            RentDuration = leaseAgreementDTO.RentDuration,
            Price = leaseAgreementDTO.Price,
            ShelvesCount = leaseAgreementDTO.ShelvesCount,
            RenterId = renter.Id
        };
        await _leaseAgreementRepository.CreateAsync(leaseAgreement);

        var shelfLeaseAgreement = new ShelfLeaseAgreement
        {
            ShelfId = shelf.Id,
            LeaseAgreementId = leaseAgreement.Id
        };

        await _shelfLeaseAgreementRepository.CreateAsync(shelfLeaseAgreement);

        return leaseAgreement.Id;
    }
}

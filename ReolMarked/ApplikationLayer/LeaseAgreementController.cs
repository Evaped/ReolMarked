using ReolMarked.DataStorageLayer;
using ReolMarked.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.ApplikationLayer;
public class LeaseAgreementController
{
    private readonly LeaseAgreementRepository _leaseAgreementRepository;
    public LeaseAgreementController(LeaseAgreementRepository leaseAgreementRepository)
    {
        _leaseAgreementRepository = leaseAgreementRepository;
    }

    public void add(LeaseAgreement entity)
    {
        _leaseAgreementRepository.CreateAsync(entity);
    }
}

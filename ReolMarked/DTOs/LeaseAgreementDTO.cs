using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.DTOs;
public class LeaseAgreementDTO
{
    public DateTime StartDate { get; set; }
    public int RentDuration { get; set; }
    public double Price { get; set; }
    public int ShelvesCount { get; set; }
    public string Email { get; set; }

    public LeaseAgreementDTO MapLeaseAgreementToDTO(LeaseAgreementDTO leaseAgreement)
    {
        return new LeaseAgreementDTO
        {
            StartDate = leaseAgreement.StartDate,
            RentDuration = leaseAgreement.RentDuration,
            Price = leaseAgreement.Price,
            ShelvesCount = leaseAgreement.ShelvesCount,
            Email = leaseAgreement.Email
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace ReolMarked.DomainLayer;

[PrimaryKey(nameof(LeaseAgreementId), nameof(ShelfId))]
public class ShelfLeaseAgreement
{
    public Shelf Shelf { get; set; } = null;
    public int ShelfId { get; set; }

    public LeaseAgreement LeaseAgreement { get; set; } = null;
    public int LeaseAgreementId { get; set; }
    
}
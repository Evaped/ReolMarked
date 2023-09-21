namespace ReolMarked.DomainLayer;

public class ShelfLeaseAgreement
{
    public Shelf Shelf { get; set; } = null;
    public int ShelfId { get; set; }

    public Renter Renter { get; set; } = null;
    public int RenterId { get; set; }
    
}
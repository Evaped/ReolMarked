namespace ReolMarked.DomainLayer;

public class ShelfLeaseAgreement
{
    public Shelf Shelf { get; set; }
    public int ShelfId { get; set; }

    public Renter Renter { get; set; }
    public int RenterId { get; set; }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked;
public class Shelf
{
    public int Id { get; set; }
    public string Location { get; set; }
    public ShelfType ShelfType { get; set; }
    
    public DateTime BookingStartDate { get; set; } 
    public DateTime BookingEndDate { get; set; }
}

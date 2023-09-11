using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ReolMarked.DomainLayer
{
    public class LeaseAgreement
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int RentDuration { get; set; }
        public bool IsPaid { get; set; }
        public double PaidAmount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

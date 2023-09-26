using ReolMarked.DataStorageLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.Controllers;
public class RenterController
{
    private readonly RenterRepository _renterRepository;

    public RenterController(RenterRepository renterRepository)
    {
        _renterRepository = renterRepository;
    }
}

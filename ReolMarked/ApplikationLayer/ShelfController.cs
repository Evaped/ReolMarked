using ReolMarked.DataStorageLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.ApplikationLayer;
public class ShelfController
{
    private readonly ShelfRepository _shelfRepository;

    public ShelfController(ShelfRepository shelfRepository)
    {
        _shelfRepository = shelfRepository;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReolMarked.DTOs;
public class ShelfDTO
{
    public string Location { get; set; }
    public ShelfType ShelfType { get; set; }

    public ShelfDTO MapShelfToDTO(Shelf shelf)
    {
        return new ShelfDTO
        {
            Location = shelf.Location,
            ShelfType = (ShelfType)shelf.ShelfType
        };
    }
}

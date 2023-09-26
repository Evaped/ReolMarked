using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ReolMarked.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PriceController : ControllerBase
{
    // POST: api/Shelf
    [HttpPost]
    public async Task<PriceDto> GetPrice(int shelfCount, int weeksCount, ShelfType shelftype)
    {
        var priceDto = new PriceDto
        {
            Price = 0,
            Discount = 0
        };
        double discountPercent;

        if (weeksCount >= 4 && weeksCount < 8)
        {
            discountPercent = 0.875;
        }
        else if (weeksCount >= 8)
        {
            discountPercent = 0.75;
        }

        else
        {
            discountPercent = 1;
        }

        priceDto.Price = (shelfCount * 100 * weeksCount) * discountPercent;
        priceDto.Discount = (shelfCount * 100 * weeksCount) - priceDto.Price;

        return priceDto;
    }
}


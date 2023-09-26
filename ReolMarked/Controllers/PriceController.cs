using ReolMarked.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReolMarked.Controllers;
/*
public class PriceController : PriceDto
{
    public PriceDto GetPrice (int shelfCount, int weeksCount, ShelfType shelfType)
    {
        double basePricePerWeek = 50;
        double pricePerShelf = 10;
        double discountMultiplier = 1.0;

        if ( shelfType == ShelfType.withGlass)
        {
            discountMultiplier = 0.9;
        }

        double totalPrice = (basePricePerWeek * weeksCount) + (pricePerShelf * (double)shelfType * weeksCount);
        totalPrice *= discountMultiplier;

        var priceDto = new PriceDto
        {
            Price = totalPrice,
            Discount = discountMultiplier < 1.0
        };

        return priceDto;
    }
}
*/

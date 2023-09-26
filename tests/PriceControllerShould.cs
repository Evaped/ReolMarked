using ReolMarked.DTOs;

namespace tests
{
    public class PriceControllerShould
    {
        [Fact]
        public async Task GetPricePerWeek()
        {
            var leaseAgreementDTO = new LeaseAgreementDTO()
            {
                StartDate = DateTime.Now,
                RentDuration = 4,
                ShelvesCount = 1,
                Price = 100,
                Email = "Jørgen.Hansen@hot.dk"
            };
            var priceDto = GetPriceDTO(leaseAgreementDTO);

            Assert.Equal(350, priceDto.Price);
            Assert.Equal(50, priceDto.Discount);
        }

        [Fact]
        public async Task GetPriceAndDiscountForOneShelfAndSexWeeks()
        {
            var Lease2DTO = new LeaseAgreementDTO()
            {
                StartDate = DateTime.Now,
                RentDuration = 6,
                Price = 500,
                ShelvesCount = 1,
                Email = "email@benni.com",
            };

            var priceDto = GetPriceDTO(Lease2DTO);

            Assert.Equal(525, priceDto.Price);
            Assert.Equal(75, priceDto.Discount);

        }

        public PriceDto GetPriceDTO(LeaseAgreementDTO leaseAgreementDTO)
        {
            var priceDto = new PriceDto
            {
                Price = 0,
                Discount = 0
            };
            double discountPercent;

            if (leaseAgreementDTO.RentDuration >= 4 || leaseAgreementDTO.RentDuration < 8)
            {
                discountPercent = 0.875;
            }
            else if (leaseAgreementDTO.RentDuration >= 8)
            {
                discountPercent = 0.75;
            }

            else
            {
                discountPercent = 1;
            }


            priceDto.Price = (leaseAgreementDTO.ShelvesCount * 100 * leaseAgreementDTO.RentDuration) * discountPercent;
            priceDto.Discount = (leaseAgreementDTO.ShelvesCount * 100 * leaseAgreementDTO.RentDuration) - priceDto.Price;

            return priceDto;
        }
    }
}

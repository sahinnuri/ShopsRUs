using ShopsRUs.Shared.Enum;

namespace ShopsRUs.Shared.DTO
{
    public class OrderDetailDTO
    {
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public CurrencyEnum Currency { get; set; }
        public string ProductName { get; set; }
    }
}

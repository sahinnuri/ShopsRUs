using ShopsRUs.Business.Interfaces;
using ShopsRUs.Shared.DTO;
using ShopsRUs.Shared.Enum;
using System;
using System.Linq;

namespace ShopsRUs.Business
{
    public class OrderService : IOrderService
    {
        public OrderResponseDTO CalculateDiscount(OrderRequestDTO orderRequestDTO)
        {
            try
            {


                decimal percent5 = Convert.ToDecimal(0.05);
                decimal percent10 = Convert.ToDecimal(0.10);
                decimal percent30 = Convert.ToDecimal(0.30);

                OrderResponseDTO responseDTO = new OrderResponseDTO();

                var totalAmount = orderRequestDTO.OrderDetailList.Sum(q => (q.Amount * q.Quantity));
                responseDTO.TotalAmount = totalAmount;

                if (orderRequestDTO.OrderDetailList.FirstOrDefault().Currency == CurrencyEnum.USD)
                {
                    var totalAmountMod = Math.Floor(totalAmount / 100);
                    var fixedDiscount = totalAmountMod * 5;
                    responseDTO.TotalAmount -= fixedDiscount;
                    responseDTO.TotalDiscount += fixedDiscount;
                }


                if (orderRequestDTO.Platform != PlatformEnum.Groceries)
                {
                    decimal calculatedPercentAmount = 0;
                    switch (orderRequestDTO.UserType)
                    {
                        case UserTypeEnum.Employee:
                            calculatedPercentAmount = totalAmount * percent30;
                            break;
                        case UserTypeEnum.Affiliate:
                            calculatedPercentAmount = totalAmount * percent10;
                            break;
                        case UserTypeEnum.Customer:
                            calculatedPercentAmount = totalAmount * percent5;
                            break;
                        case UserTypeEnum.EmployeeAndCustomer:
                            calculatedPercentAmount = totalAmount * percent30;
                            break;
                        case UserTypeEnum.AffiliateAndCustomer:
                            calculatedPercentAmount = totalAmount * percent10;
                            break;
                        default:
                            break;
                    }
                    responseDTO.TotalAmount -= calculatedPercentAmount;
                    responseDTO.TotalDiscount += calculatedPercentAmount;
                }


                return responseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("İndirim hesaplanırken hata alındı.");
            }
        }
    }
}

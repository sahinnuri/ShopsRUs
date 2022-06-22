using ShopsRUs.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Business.Interfaces
{
    public interface IOrderService
    {
        OrderResponseDTO CalculateDiscount(OrderRequestDTO orderRequestDTO);
    }
}

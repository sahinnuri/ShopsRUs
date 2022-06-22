using ShopsRUs.Shared.Enum;
using System;
using System.Collections.Generic;

namespace ShopsRUs.Shared.DTO
{
    public class OrderRequestDTO
    {
        public OrderRequestDTO()
        {
            OrderDetailList = new List<OrderDetailDTO>();
        }
        public UserTypeEnum UserType { get; set; }
        public PlatformEnum Platform { get; set; }
        public List<OrderDetailDTO> OrderDetailList { get; set; }
    }
    public class OrderResponseDTO
    {
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
    }
}

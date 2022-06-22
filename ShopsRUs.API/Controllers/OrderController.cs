using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Business;
using ShopsRUs.Business.Interfaces;
using ShopsRUs.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("CalculateDiscount")]
        public OrderResponseDTO CalculateDiscount(OrderRequestDTO orderRequestDTO)
        {
            return _orderService.CalculateDiscount(orderRequestDTO);
        }
    }
}

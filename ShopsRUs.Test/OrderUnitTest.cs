using ShopsRUs.Shared.DTO;
using ShopsRUs.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;

namespace ShopsRUs.Test
{
    public class OrderUnitTest
    {
        [Fact]
        public async void CalculateDiscount()
        {
            OrderRequestDTO orderRequestDTO = new OrderRequestDTO();
            var client = new TestClientProvider().client;
            OrderDetailDTO orderDetailDTO;

            #region DummyData

            orderRequestDTO.Platform = PlatformEnum.Web;
            orderRequestDTO.UserType = UserTypeEnum.Customer;

            orderDetailDTO = new OrderDetailDTO();
            orderDetailDTO.Amount = 100;
            orderDetailDTO.Quantity = 5;
            orderDetailDTO.Currency = CurrencyEnum.USD;
            orderDetailDTO.ProductName = "Product1";
            orderRequestDTO.OrderDetailList.Add(orderDetailDTO);

            orderDetailDTO = new OrderDetailDTO();
            orderDetailDTO.Amount = 500;
            orderDetailDTO.Quantity = 2;
            orderDetailDTO.Currency = CurrencyEnum.USD;
            orderDetailDTO.ProductName = "Product2";
            orderRequestDTO.OrderDetailList.Add(orderDetailDTO);
            #endregion

            var result = await client.PostAsJsonAsync("api/Order/CalculateDiscount", orderRequestDTO);
            var responseData = await result.Content.ReadFromJsonAsync<OrderResponseDTO>();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}

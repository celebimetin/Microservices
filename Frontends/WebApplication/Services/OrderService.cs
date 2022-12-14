using Shared.Dtos;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication.Models.FakePayments;
using WebApplication.Models.Orders;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrderService(HttpClient httpClient, IPaymentService paymentService, IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _httpClient = httpClient;
            _paymentService = paymentService;
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkOutInfoInput)
        {
            var basket = await _basketService.GetAsync();
            var paymentInfoInput = new FakePaymentInfoInput()
            {
                CardName = checkOutInfoInput.CardName,
                CardNumber = checkOutInfoInput.CardNumber,
                CVV = checkOutInfoInput.CVV,
                Expiration = checkOutInfoInput.Expiration,
                TotalPrice = basket.TotalPrice
            };

            var responsePayment = await _paymentService.ReceivePayment(paymentInfoInput);
            if (!responsePayment)
            {
                return new OrderCreatedViewModel() { Error = "Ödeme alınamadı.", IsSuccessful = false };
            }

            var orderCreateInput = new OrderCreateInput()
            {
                BuyerId = _sharedIdentityService.GetUserId,
                Address = new AddressCreateInput
                {
                    Province = checkOutInfoInput.Province,
                    District = checkOutInfoInput.District,
                    Street = checkOutInfoInput.Street,
                    Line = checkOutInfoInput.Line,
                    ZipCode = checkOutInfoInput.ZipCode
                },
            };

            basket.BasketItems.ForEach(x =>
            {
                var orderItem = new OrderItemCreateInput
                {
                    ProductId = x.CourseId,
                    ProductName = x.CourseName,
                    Price = x.GetCurrentPrice,
                    PictureUrl = ""
                };
                orderCreateInput.OrderItems.Add(orderItem);
            });

            var response = await _httpClient.PostAsJsonAsync<OrderCreateInput>("orders/CreateOrder", orderCreateInput);
            if (!response.IsSuccessStatusCode)
            {
                return new OrderCreatedViewModel() { Error = "Sipariş oluşturulamadı.", IsSuccessful = false };
            }
            var orderCreated = await response.Content.ReadFromJsonAsync<OrderCreatedViewModel>();
            orderCreated.IsSuccessful = true;
            return orderCreated;
        }

        public async Task<List<OrderViewModel>> GetOrder()
        {
            var response = await _httpClient.GetFromJsonAsync<Response<List<OrderViewModel>>>("orders/GetOrders");
            return response.Data;
        }

        public async Task SuspendOrder(CheckoutInfoInput checkOutInfoInput)
        {
            throw new NotImplementedException();
        }
    }
}
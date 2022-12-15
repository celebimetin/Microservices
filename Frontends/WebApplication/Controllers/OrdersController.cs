using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication.Models.Orders;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public OrdersController(IBasketService basketService, IOrderService orderService)
        {
            _basketService = basketService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Checkout()
        {
            var basket = await _basketService.GetAsync();
            ViewBag.basket = basket;

            return View(new CheckoutInfoInput());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutInfoInput checkoutInfoInput)
        {
            //1.ci yol senkron iletişim istek atılıp cevap beklenir
            //var orderStatus = await _orderService.CreateOrder(checkoutInfoInput);

            //2.ci yol asenkron iletişim istek atılıp cevap beklenmez
            var orderSuspendStatus = await _orderService.SuspendOrder(checkoutInfoInput);

            if (!orderSuspendStatus.IsSuccessful)
            {
                var basket = await _basketService.GetAsync();
                ViewBag.basket = basket;
                ViewBag.error = orderSuspendStatus.Error;
                return View();
            }

            //1.ci yol senkron iletişim istek atılıp cevap beklenir
            //return RedirectToAction(nameof(SuccessfulCheckout), new { orderId = orderStatus.OrderId });

            //2.ci yol asenkron iletişim istek atılıp cevap beklenmez
            return RedirectToAction(nameof(SuccessfulCheckout), new { orderId = new Random().Next(1, 1000) });
        }

        public IActionResult SuccessfulCheckout(int orderId)
        {
            ViewBag.orderId = orderId;
            return View();
        }

        public async Task<IActionResult> CheckoutHistory()
        {
            return View(await _orderService.GetOrder());
        }
    }
}
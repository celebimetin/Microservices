using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models.Orders;

namespace WebApplication.Services.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Sekron iletişim & direk order microservice'ne istek yapılacak
        /// </summary>
        /// <param name="checkOutInfoInput"></param>
        /// <returns></returns>
        Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkOutInfoInput);

        /// <summary>
        /// Asenkron iletişim & sipariş bilgileri RabbitMQ'ya gönderilecek
        /// </summary>
        /// <param name="checkOutInfoInput"></param>
        /// <returns></returns>
        Task SuspendOrder(CheckoutInfoInput checkOutInfoInput);
        Task<List<OrderViewModel>> GetOrder();
    }
}
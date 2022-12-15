using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Services.FakePayment.Models;
using Shared.ControllerBases;
using Shared.Dtos;
using Shared.Messages;
using System.Threading.Tasks;

namespace Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public FakePaymentsController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task<IActionResult> ReceivePayment(FakePaymentDto fakePaymentDto)
        {
            var sendEnpoint = await _sendEndpointProvider.GetSendEndpoint(new System.Uri("queue:create-order-service"));

            var createOrderMessageCommand = new CreateOrderMessageCommand();
            createOrderMessageCommand.BuyerId = fakePaymentDto.Order.BuyerId;
            createOrderMessageCommand.Province = fakePaymentDto.Order.Address.Province;
            createOrderMessageCommand.District = fakePaymentDto.Order.Address.District;
            createOrderMessageCommand.Street = fakePaymentDto.Order.Address.Street;
            createOrderMessageCommand.Line = fakePaymentDto.Order.Address.Line;
            createOrderMessageCommand.ZipCode = fakePaymentDto.Order.Address.ZipCode;

            fakePaymentDto.Order.OrderItems.ForEach(x =>
            {
                createOrderMessageCommand.OrderItems.Add(new OrderItem
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    PictureUrl = x.PictureUrl
                });
            });

            await sendEnpoint.Send<CreateOrderMessageCommand>(createOrderMessageCommand);
            return CreateActionResultInstance(Shared.Dtos.Response<NoContent>.Success(200));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Services.FakePayment.Models;
using Shared.ControllerBases;
using Shared.Dtos;

namespace Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {
        [HttpPost]
        public IActionResult ReceivePayment(FakePaymentDto fakePaymentDto)
        {
            return CreateActionResultInstance(Response<NoContent>.Success(204));
        }
    }
}
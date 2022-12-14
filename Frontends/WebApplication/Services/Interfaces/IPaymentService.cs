using System.Threading.Tasks;
using WebApplication.Models.FakePayments;

namespace WebApplication.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> ReceivePayment(FakePaymentInfoInput fakePaymentInfoInput);
    }
}
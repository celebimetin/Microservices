using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication.Models.FakePayments;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ReceivePayment(FakePaymentInfoInput fakePaymentInfoInput)
        {
            var response = await _httpClient.PostAsJsonAsync<FakePaymentInfoInput>($"FakePayments", fakePaymentInfoInput);
            return response.IsSuccessStatusCode;
        }
    }
}
using Shared.Dtos;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication.Models.Baskets;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IDiscountService _discountService;

        public BasketService(HttpClient httpClient, IDiscountService discountService)
        {
            _httpClient = httpClient;
            _discountService = discountService;
        }

        public async Task AddBasketItemAsync(BasketItemViewModel basketItemViewModel)
        {
            var basket = await GetAsync();
            if (basket != null)
            {
                if (!basket.BasketItems.Any(x => x.CourseId == basketItemViewModel.CourseId))
                {
                    basket.BasketItems.Add(basketItemViewModel);
                }
            }
            else
            {
                var a = new BasketViewModel();
                a.BasketItems.Add(basketItemViewModel);
                await SaveOrUpdateAsync(a);
            }
            await SaveOrUpdateAsync(basket);
        }

        public async Task<bool> ApplyDiscount(string discountCode)
        {
            await CancelApplyDiscount();
            var basket = await GetAsync();
            if (basket == null || basket.DiscountCode == null) return false;

            var hasDiscount = await _discountService.GetDiscount(discountCode);
            if (hasDiscount == null) return false;

            basket.DiscountRate = hasDiscount.Rate;
            basket.DiscountCode = hasDiscount.Code;
            await SaveOrUpdateAsync(basket);
            return true;
        }

        public async Task<bool> CancelApplyDiscount()
        {
            var basket = await GetAsync();
            if (basket == null || basket.DiscountCode == null) return false;
            basket.DiscountCode = null;
            await SaveOrUpdateAsync(basket);
            return true;
        }

        public async Task<bool> DeleteAsync()
        {
            var result = await _httpClient.DeleteAsync("baskets/DeleteBasket");
            return result.IsSuccessStatusCode;
        }

        public async Task<BasketViewModel> GetAsync()
        {
            var response = await _httpClient.GetAsync("Baskets/GetBasket");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var basketViewModel = await response.Content.ReadFromJsonAsync<Response<BasketViewModel>>();
            return basketViewModel.Data;
        }

        public async Task<bool> RemoveBasketItemAsync(string courseId)
        {
            var basket = await GetAsync();
            if (basket == null) return false;

            var deleteBasketItem = basket.BasketItems.FirstOrDefault(x => x.CourseId == courseId);
            if (deleteBasketItem == null) return false;

            var deleteResult = basket.BasketItems.Remove(deleteBasketItem);
            if (!deleteResult) return false;
            if (!basket.BasketItems.Any()) basket.DiscountCode = null;

            return await SaveOrUpdateAsync(basket);
        }

        public async Task<bool> SaveOrUpdateAsync(BasketViewModel basketViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync<BasketViewModel>("baskets/CreateOrUpdateBasket", basketViewModel);
            return response.IsSuccessStatusCode;
        }
    }
}
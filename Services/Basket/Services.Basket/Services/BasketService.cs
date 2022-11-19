using Services.Basket.Dtos;
using Shared.Dtos;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> DeleteAsync(string userId)
        {
            var status = await _redisService.GetDatabase().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket not found", 404);
        }

        public async Task<Response<BasketDto>> GetBasketAsync(string userId)
        {
            var existBasket = await _redisService.GetDatabase().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Basket not found", 404);
            }
            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
        }

        public async Task<Response<bool>> CreateOrUpdateAsync(BasketDto basketDto)
        {
            var status = await _redisService.GetDatabase().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not update or save", 500);
        }
    }
}
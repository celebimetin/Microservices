using Services.Basket.Dtos;
using Shared.Dtos;
using System.Threading.Tasks;

namespace Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasketAsync(string userId);
        Task<Response<bool>> CreateOrUpdateAsync(BasketDto basketDto);
        Task<Response<bool>> DeleteAsync(string userId);
    }
}
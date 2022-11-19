using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<Models.Discount>>> GetAllAsync();
        Task<Response<Models.Discount>> GetByIdAsync(int id);
        Task<Response<Models.Discount>> GeyByCodeAndUserIdAsync(string userId, string code);
        Task<Response<NoContent>> CreateAsync(Models.Discount discount);
        Task<Response<NoContent>> UpdateAsync(Models.Discount discount);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
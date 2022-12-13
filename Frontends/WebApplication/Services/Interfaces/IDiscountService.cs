using System.Threading.Tasks;
using WebApplication.Models.Discounts;

namespace WebApplication.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);
    }
}
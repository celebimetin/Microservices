using Microsoft.AspNetCore.Mvc;
using Services.Discount.Services;
using Shared.ControllerBases;
using Shared.Services;
using System.Threading.Tasks;

namespace Services.Discount.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public DiscountsController(IDiscountService discountService, ISharedIdentityService sharedIdentityService)
        {
            _discountService = discountService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _discountService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountService.GetByIdAsync(id);
            return CreateActionResultInstance(discount);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var userId = _sharedIdentityService.GetUserId;
            var discount = await _discountService.GeyByCodeAndUserIdAsync(userId, code);
            return CreateActionResultInstance(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Discount discount)
        {
            var response = await _discountService.CreateAsync(discount);
            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            var response = await _discountService.UpdateAsync(discount);
            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _discountService.DeleteAsync(id);
            return CreateActionResultInstance(response);
        }
    }
}
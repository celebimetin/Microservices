using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Discounts
{
    public class DiscountApplyInput
    {
        [Display(Name = "İndirim Kodu")]
        public string Code { get; set; }
    }
}
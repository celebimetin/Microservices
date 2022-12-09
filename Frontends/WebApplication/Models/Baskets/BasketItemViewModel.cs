namespace WebApplication.Models.Baskets
{
    public class BasketItemViewModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        private decimal? DiscountAppliedPrice { get; set; }

        public decimal GetCurrentPrice { get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : Price; }

        public void AppliedDiscount(decimal discountPrice)
        {
            DiscountAppliedPrice = discountPrice;
        }
    }
}
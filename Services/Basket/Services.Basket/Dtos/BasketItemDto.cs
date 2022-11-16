namespace Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
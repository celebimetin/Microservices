using System;
using System.Collections.Generic;

namespace WebApplication.Models.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}
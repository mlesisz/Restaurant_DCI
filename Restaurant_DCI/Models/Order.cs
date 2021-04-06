using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_DCI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
        public string Comment { get; set; }
        public OrderState OrderState { get; set; }

    }

    public enum OrderState
    {
        New,
        InProgress,
        Ready,
        Sent,
        Delivered
    }
}
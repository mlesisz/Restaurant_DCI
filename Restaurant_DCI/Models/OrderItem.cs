using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Restaurant_DCI.RoleMethods;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.Models
{
    public class OrderItem : CompleteTheOrderContex.IOrderItem
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool Done { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
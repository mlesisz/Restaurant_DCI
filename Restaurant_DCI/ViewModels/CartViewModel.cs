using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_DCI.Models;

namespace Restaurant_DCI.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Models
{
    public class CartItem : IPlaceAnOrderCartItem
    {
        public Product Product { get; set; }
        [Display(Name = "Liczba")]
        [Range(0,100)]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Cena całkowita")]
        public decimal TotalPrice { get; set; }
        public CartItem()
        {
            Quantity = 1;
        }
    }
}
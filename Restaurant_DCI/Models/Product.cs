using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Models
{
    public class Product : IBrowsingMemuProduct, IEditingTheMenuProduct
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [Display(Name ="Nazwa")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
        [Display(Name = "Przepis")]
        public string Recipe { get; set; }
    }
}
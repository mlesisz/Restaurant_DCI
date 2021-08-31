using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant_DCI.RoleMethods;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.Models
{
    public class Product : BrowsingMenuContex.IProduct, EditingTheMenuContex.IProduct
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
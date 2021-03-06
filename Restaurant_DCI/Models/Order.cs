using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;
using Restaurant_DCI.RoleMethods;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.Models
{
    public class Order : PlaceAnOrderContex.IOrder, BrowsingOrdersContex.IOrder
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
        [Display(Name ="Uwagi do zamówienia")]
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderState OrderState { get; set; }
        [Required(ErrorMessage = "Wybierz metode płatności")]
        [Display(Name ="Metoda płatności")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required(ErrorMessage = "Wprowadź imie i nazwisko")]
        [StringLength(150)]
        [Display(Name ="Imie i Nazwisko")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić numer telefonu")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+",
            ErrorMessage = "Błędny format numeru telefonu.")]
        [Display(Name ="Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Nie wprowadzono adresu")]
        [StringLength(150)]
        [Display(Name ="Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Wprowadź kod pocztowy i miasto")]
        [StringLength(50)]
        [Display(Name ="Kod pocztowy oraz Miejscowość")]
        public string CodeAndCity { get; set; }
    }

    public enum PaymentMethod
    {
        [Display(Name ="Gotówka")]
        CashPayment,
        [Display(Name ="Karta płatnicza")]
        CardPayment
    }

    public enum OrderState
    {
        [Display(Name ="Nowe")]
        New,
        [Display(Name ="W trakcie przygotowania")]
        InProgress,
        [Display(Name ="Gotowe")]
        Ready,
        [Display(Name ="W trakcie wysyłki")]
        Sent,
        [Display(Name ="Dostarczone")]
        Delivered
    }
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
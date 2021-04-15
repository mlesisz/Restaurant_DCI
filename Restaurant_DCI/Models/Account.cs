using Restaurant_DCI.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant_DCI.Models
{
    public abstract class Account 
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name ="Imie")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Musisz wprowadzić e-mail")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Wprowadź poprawnie e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasło i hasło potwierdzające nie pasują do siebie.")]
        public string ConfirmPassword { get; set; }
    }
    
    public class RegistrantAccount : Account, IRegisterUser
    {
    }

    public class LoginAccount : Account, ILoginUser 
    {
    }
}
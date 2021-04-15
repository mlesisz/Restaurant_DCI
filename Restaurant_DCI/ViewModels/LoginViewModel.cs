using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Musisz wprowadzić e-mail")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Wprowadź poprawnie e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
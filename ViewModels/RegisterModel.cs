using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFDataApp.ViewModels
{
    public class RegisterModel
    {
        [Key]
        [Required(ErrorMessage = "Email nie został podany")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło nie zostało podane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Niepoprawne hasło")]
        public string ConfirmPassword { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ulica { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Miejscowosc { get; set; }
    }
}

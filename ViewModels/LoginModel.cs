using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFDataApp.ViewModels
{
    public class LoginModel
    { 
        [Key]
        [Required(ErrorMessage = "Email nie został podany")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło nie zostało podane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDataApp.Models
{
    public class Student
    {
        [Key]
        public int Id_student { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ulica { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public ICollection<Student_Oceny> Student_Oceny { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataApp.Models
{
    public class Student_Oceny
    {
        [Key]
        public int Id_oceny { get; set; }
        public int Ocena { get; set; }
        public string Ocena_slownie { get; set; }

        [ForeignKey("Id_student")]
        [Required]
        public int Id_student { get; set; }
        public Student Student { get; set; }
    }
}

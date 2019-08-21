using Microsoft.EntityFrameworkCore;

namespace EFDataApp.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Student_Oceny> Student_Oceny { get; set; }
        public MobileContext(DbContextOptions<MobileContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

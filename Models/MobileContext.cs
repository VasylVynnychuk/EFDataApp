using Microsoft.EntityFrameworkCore;
using EFDataApp.ViewModels;

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
        public DbSet<EFDataApp.ViewModels.RegisterModel> RegisterModel { get; set; }
    }
}

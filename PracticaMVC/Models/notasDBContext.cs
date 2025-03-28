using Microsoft.EntityFrameworkCore;

namespace PracticaMVC.Models
{
    public class notasDBContext : DbContext
    {
        public notasDBContext(DbContextOptions<notasDBContext> options) : base(options)
        {
        }
        public DbSet<alumnos> alumnos { get; set; }
        public DbSet<departamentos> departamentos { get; set; }
        public DbSet<facultades> facultades { get; set; }
        public DbSet<materias> materias { get; set; }
    }
}

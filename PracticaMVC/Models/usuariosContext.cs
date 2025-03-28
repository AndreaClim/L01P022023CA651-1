using Microsoft.EntityFrameworkCore;

namespace PracticaMVC.Models
{
    public class usuariosContext : DbContext
    {
        public usuariosContext(DbContextOptions<usuariosContext> options) : base(options)
        {
        }

        public DbSet<usuarios> usuarios { get; set; }
    }
}

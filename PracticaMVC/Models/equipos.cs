using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class equipos
    {
        [Key]
        public int equipos_id { get; set; }
        public int id_marcas { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public int stock { get; set; }
        public double precio { get; set; }

    }
}

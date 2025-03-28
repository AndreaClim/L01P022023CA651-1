using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class facultades
    {
        [Key]
        public int id { get; set; }
        public string facultad { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class departamentos
    {
        [Key]
        public int id { get; set; }
        public string departamento { get; set; }
    }
}

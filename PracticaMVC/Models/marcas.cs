using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class marcas
    {
        [Key]
        [Display(Name ="ID")]
        [Required]
        public int id_marcas { get; set; }
        [Required(ErrorMessage ="El nombre de la marca NO es opcional")]
        [Display(Name = "Nombre de la Marca")]
        public string? nombre_marca { get; set; }
        [Display(Name = "Estado")]
        public string? estados { get; set; }    
    }
}

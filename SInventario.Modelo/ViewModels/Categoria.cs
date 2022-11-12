using System.ComponentModel.DataAnnotations;

namespace SInventario.Modelo.ViewModels
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre de Categoria")]
        public string Nombre { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SInventario.Modelo.ViewModels
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string UsuarioAplicacionId { get; set; }
        [ForeignKey("UsuarioAplicacionId")]
        public UsuarioAplicacion UsuarioAplicacion { get; set; }
        [Required]
        [Display(Name = "Fecha Inicial")]
        [DisplayFormat(ApplyFormatInEditMode =false, DataFormatString ="{0:MM-DD-YYYY HH:MM}")]
        public DateTime FechaInicio { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MM-DD-YYYY HH:MM}")]
        public DateTime FechaFinal { get; set; }
        [Required]
        [Display(Name = "Bodega")]
        public int BodegaId { get; set; }
        [ForeignKey("BodegaId")]
        public Bodega Bodega { get; set; }
        public bool Estado { get; set; }
    }
}

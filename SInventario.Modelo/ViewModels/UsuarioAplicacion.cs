using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SInventario.Modelo.ViewModels
{
    public class UsuarioAplicacion : IdentityUser
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Pais { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}

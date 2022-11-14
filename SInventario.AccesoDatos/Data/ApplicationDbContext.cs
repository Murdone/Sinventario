using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SInventario.Modelo.ViewModels;

namespace SInventario.AccesoDatos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> marcas { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<UsuarioAplicacion> UsuarioAplicacions { get; set; }
    }
}

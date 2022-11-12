using SInventario.Modelo.ViewModels;

namespace SInventario.AccesoDatos.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        void Actualizar(Categoria categoria);
    }
}

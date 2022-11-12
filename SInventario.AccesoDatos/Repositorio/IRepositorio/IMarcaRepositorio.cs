using SInventario.Modelo.ViewModels;
using System.Text.RegularExpressions;

namespace SInventario.AccesoDatos.Repositorio.IRepositorio
{
    public interface IMarcaRepositorio : IRepositorio<Marca>
    {
        void Actualizar(Marca marca);

    }
}

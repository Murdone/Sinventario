using SInventario.Modelo.ViewModels;

namespace SInventario.AccesoDatos.Repositorio.IRepositorio
{
    public internal interface IBodegaRepositorio : IRepositorio<Bodega>
    {
        void Actualizar(Bodega bodega);
    }
}

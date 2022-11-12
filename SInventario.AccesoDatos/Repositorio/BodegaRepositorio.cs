using SInventario.AccesoDatos.Repositorio.IRepositorio;
using SInventario.Modelo.ViewModels;
using System.Linq;

namespace SInventario.AccesoDatos.Repositorio
{
    public class BodegaRepositorio : Repositorio<Bodega>, IBodegaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public BodegaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Bodega bodega)
        {
            var BodegasDb = _db.Bodegas.FirstOrDefault(b => b.Id == bodega.Id);
            if (BodegasDb != null)
            {
                BodegasDb.Nombre = bodega.Nombre;
                BodegasDb.Descripcion = bodega.Descripcion;
                BodegasDb.Estado = bodega.Estado;


            }
        }
    }
}

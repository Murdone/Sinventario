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
            var BodegaDb = _db.Bodegas.FirstOrDefault(b => b.Id == bodega.Id);
            if(BodegaDb !=null) 
            {
                bodega.Nombre = BodegaDb.Nombre;
                bodega.Descripcion = BodegaDb.Descripcion;
                bodega.Estado = BodegaDb.Estado;
                _db.SaveChanges();
            }
        }
    }
}

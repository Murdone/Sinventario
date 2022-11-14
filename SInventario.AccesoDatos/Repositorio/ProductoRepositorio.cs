using SInventario.AccesoDatos.Repositorio.IRepositorio;
using SInventario.Modelo.ViewModels;
using System;
using System.Linq;

namespace SInventario.AccesoDatos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Producto producto)
        {
            var productoDb = _db.productos.FirstOrDefault(p => p.Id == producto.Id);
            if(productoDb != null) 
            {
              if(producto.ImagenUrl != null) 
              {
                    producto.ImagenUrl = productoDb.ImagenUrl;
              }
              if(producto.PadreId == 0) 
              {
                    productoDb.PadreId = null;
              }
              else 
              {
                    productoDb.PadreId = productoDb.PadreId;
              }
                productoDb.NumeroSerie = producto.NumeroSerie;
                productoDb.Descripcion = producto.Descripcion;
                productoDb.Precio = producto.Precio;
                productoDb.Costo = producto.Costo;
                productoDb.CategoriaId = producto.CategoriaId;
                productoDb.MarcaId = producto.MarcaId;

            }
        }
    }
}

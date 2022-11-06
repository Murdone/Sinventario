using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SInventario.AccesoDatos.Repositorio.IRepositorio
{
    public interface IRepositorio1<T> where T : class
    {
        void Agregar(T entidad);
        T Obtener(int id);
        T ObtenerPrimero(Expression<Func<T, bool>> filter = null, string incluirPropiedades = null);
        IEnumerable<T> ObtenerTodos(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null);
        void Remover(IEnumerable<T> entidad);
        void Remover(int Id);
        void Remover(T entidad);
    }
}
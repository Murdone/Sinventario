using Microsoft.EntityFrameworkCore;
using SInventario.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SInventario.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repositorio(ApplicationDbContext db, DbSet<T> dbSet)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Agregar(T entidad)
        {
            dbSet.Add(entidad); // insert  into table
        }

        public T Obtener(int id)
        {
            return dbSet.Find(id); // select * frtom
        }

        public T ObtenerPrimero(Expression<Func<T, bool>> filter = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter); //select * from ...
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) // split cuando encuentre una coma que se un objeto diferente
                {
                    query = query.Include(incluirProp);
                }
            }
          
            return query.FirstOrDefault();
        }

        public IEnumerable<T> ObtenerTodos(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) {
             query = query.Where(filter); //select * from ...
            }
            if (incluirPropiedades != null) 
            {
                 foreach(var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) // split cuando encuentre una coma que se un objeto diferente
                {
                  query = query.Include(incluirProp);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public void Remover(int Id)
        {
            T enridad = dbSet.Find(Id);
            Remover(enridad);
        }

        public void Remover(T entidad)
        {
            dbSet.Remove(entidad); //delete al registro lo mas parece delete from
        }

        public void Remover(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad);
        }
    }
}

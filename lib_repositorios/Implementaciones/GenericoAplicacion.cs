using Microsoft.EntityFrameworkCore;
using lib_repositorios.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace lib_repositorios.Implementaciones
{
    public class GenericoAplicacion<T> : IGenericoAplicacion<T> where T : class
    {
        private readonly IConexion IConexion;

        public GenericoAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion.StringConexion = StringConexion;
        }

        public List<T> Listar()
        {
            return (this.IConexion as DbContext)!.Set<T>().Take(20).ToList();
        }

        public T? Guardar(T? entidad)
        {
            if (entidad == null) return null;
            (this.IConexion as DbContext)!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public T? Modificar(T? entidad)
        {
            if (entidad == null) return null;
            var entry = (this.IConexion as DbContext)!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public T? Borrar(T? entidad)
        {
            if (entidad == null) return null;
            (this.IConexion as DbContext)!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}

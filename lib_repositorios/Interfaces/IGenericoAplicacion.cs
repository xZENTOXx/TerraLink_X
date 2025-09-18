using System.Collections.Generic;

namespace lib_repositorios.Interfaces
{
    public interface IGenericoAplicacion<T> where T : class
    {
        void Configurar(string StringConexion);
        List<T> Listar();
        T? Guardar(T? entidad);
        T? Modificar(T? entidad);
        T? Borrar(T? entidad);
    }
}

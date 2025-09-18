using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class TareasAplicacion : GenericoAplicacion<Tareas>, ITareasAplicacion
    {
        public TareasAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

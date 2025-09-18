using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class EmpleadosAplicacion : GenericoAplicacion<Empleados>, IEmpleadosAplicacion
    {
        public EmpleadosAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

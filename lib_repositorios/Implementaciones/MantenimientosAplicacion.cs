using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class MantenimientosAplicacion : GenericoAplicacion<Mantenimientos>, IMantenimientosAplicacion
    {
        public MantenimientosAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

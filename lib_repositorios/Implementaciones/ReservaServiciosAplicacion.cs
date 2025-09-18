using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ReservaServiciosAplicacion : GenericoAplicacion<ReservaServicios>, IReservaServiciosAplicacion
    {
        public ReservaServiciosAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

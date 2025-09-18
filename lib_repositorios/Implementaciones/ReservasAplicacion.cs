using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ReservasAplicacion : GenericoAplicacion<Reservas>, IReservasAplicacion
    {
        public ReservasAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

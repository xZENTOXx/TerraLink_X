using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ReservaPromocionesAplicacion : GenericoAplicacion<ReservaPromociones>, IReservaPromocionesAplicacion
    {
        public ReservaPromocionesAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

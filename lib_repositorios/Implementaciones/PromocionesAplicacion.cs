using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class PromocionesAplicacion : GenericoAplicacion<Promociones>, IPromocionesAplicacion
    {
        public PromocionesAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

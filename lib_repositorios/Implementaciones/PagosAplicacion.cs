using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class PagosAplicacion : GenericoAplicacion<Pagos>, IPagosAplicacion
    {
        public PagosAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

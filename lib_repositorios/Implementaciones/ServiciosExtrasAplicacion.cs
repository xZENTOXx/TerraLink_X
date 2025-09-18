using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ServiciosExtrasAplicacion : GenericoAplicacion<ServiciosExtras>, IServiciosExtrasAplicacion
    {
        public ServiciosExtrasAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class FincasAplicacion : GenericoAplicacion<Fincas>, IFincasAplicacion
    {
        public FincasAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

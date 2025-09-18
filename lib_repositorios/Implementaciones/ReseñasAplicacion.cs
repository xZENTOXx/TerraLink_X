using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ReseñasAplicacion : GenericoAplicacion<Reseñas>, IReseñasAplicacion
    {
        public ReseñasAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class InventariosAplicacion : GenericoAplicacion<Inventarios>, IInventariosAplicacion
    {
        public InventariosAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

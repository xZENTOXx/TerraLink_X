using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ClientesAplicacion : GenericoAplicacion<Clientes>, IClientesAplicacion
    {
        public ClientesAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

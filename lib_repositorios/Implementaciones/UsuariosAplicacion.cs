using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class UsuariosAplicacion : GenericoAplicacion<Usuarios>, IUsuariosAplicacion
    {
        public UsuariosAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

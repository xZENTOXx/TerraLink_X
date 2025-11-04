using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class UsuariosAplicacion : GenericoAplicacion<Usuarios>, IUsuariosAplicacion
    {
        public UsuariosAplicacion(IConexion iConexion) : base (iConexion)
        {}
        public List<Usuarios> PorNombre_Usuario(Usuarios? entidad)
        {
            return this.IConexion!.Usuarios!
            .Where(x => x.NombreUsuario!.Contains(entidad!.NombreUsuario!))
            .Take(50)
            .ToList();
        }

    }
}

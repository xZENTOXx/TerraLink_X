using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IUsuariosAplicacion : IGenericoAplicacion<Usuarios>
    {
        List<Usuarios> PorNombre_Usuario(Usuarios? entidad);

    }
}
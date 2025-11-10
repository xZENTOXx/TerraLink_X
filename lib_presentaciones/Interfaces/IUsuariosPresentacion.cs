using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IUsuariosPresentacion : IGenericoPresentacion<Usuarios>
    {
        Task<List<Usuarios>> PorNombre_Usuario(Usuarios? entidad);
    }
}
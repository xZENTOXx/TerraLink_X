using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IUsuariosPresentacion : IGenericoPresentacion<Usuarios>
    {
        Task<List<Auditorias>> PorNombre_Usuario(Auditorias? entidad);
    }
}
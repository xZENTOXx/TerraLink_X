using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAuditoriasPresentacion : IGenericoPresentacion<Auditorias>
    {
        Task<List<Auditorias>> PorAccion(Auditorias? entidad);
        Task<List<Auditorias>> PorUsuario(int idUsuario);
        Task<List<Auditorias>> PorFecha(DateTime fecha);
    }
}

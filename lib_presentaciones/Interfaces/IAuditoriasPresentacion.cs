using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAuditoriasPresentacion : IGenericoPresentacion<Auditorias>
    {
        Task<List<Auditorias>> PorAccion(Auditorias? entidad);
    }
}
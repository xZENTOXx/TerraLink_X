using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IReseñasPresentacion : IGenericoPresentacion<Auditorias>
    {
        Task<List<Auditorias>> PorCalificacion(Auditorias? entidad);
    }
}
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ReservaPromocionesPresentacion : IGenericoPresentacion<Auditorias>
    {
        Task<List<Auditorias>> PorPromocion(Auditorias? entidad);
    }
}
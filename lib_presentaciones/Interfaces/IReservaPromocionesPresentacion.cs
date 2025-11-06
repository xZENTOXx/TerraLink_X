using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IReservaPromocionesPresentacion : IGenericoPresentacion<Auditorias>
    {
        Task<List<Auditorias>> PorPromocion(Auditorias? entidad);
    }
}
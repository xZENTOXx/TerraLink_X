using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IReservaPromocionesPresentacion : IGenericoPresentacion<ReservaPromociones>
    {
        Task<List<ReservaPromociones>> PorPromocion(ReservaPromociones? entidad);
    }
}
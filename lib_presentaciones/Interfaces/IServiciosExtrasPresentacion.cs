using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IServiciosExtrasPresentacion : IGenericoPresentacion<ServiciosExtras>
    {
        Task<List<ServiciosExtras>> PorNombre(ServiciosExtras? entidad);
    }
}
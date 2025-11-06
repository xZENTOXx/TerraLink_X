using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ServiciosExtrasPresentacion : IGenericoPresentacion<ServiciosExtras>
    {
        Task<List<ServiciosExtras>> PorNombre(ServiciosExtras? entidad);
    }
}
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ReservaServiciosPresentacion : IGenericoPresentacion<ReservaServicios>
    {
        Task<List<ReservaServicios>> PorServicio(ReservaServicios? entidad);
    }
}
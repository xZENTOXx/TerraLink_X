using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IReservaServiciosPresentacion : IGenericoPresentacion<ReservaServicios>
    {
        Task<List<ReservaServicios>> PorServicio(ReservaServicios? entidad);
    }
}
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface MantenimientosPresentacion : IGenericoPresentacion<Mantenimientos>
    {
        Task<List<Mantenimientos>> PorResponsable(Mantenimientos? entidad);
    }
}
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IMantenimientosPresentacion : IGenericoPresentacion<Mantenimientos>
    {
        Task<List<Mantenimientos>> PorResponsable(Mantenimientos? entidad);
    }
}
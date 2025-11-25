using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IMantenimientosPresentacion : IGenericoPresentacion<Mantenimientos>
    {
        Task<List<Mantenimientos>> PorResponsable(Mantenimientos? entidad);
        Task<List<Mantenimientos>> PorFecha(Mantenimientos? entidad);
        Task<List<Fincas>> ListarFincas();

    }
}
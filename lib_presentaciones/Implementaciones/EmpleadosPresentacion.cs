using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface EmpleadosPresentacion : IGenericoPresentacion<Empleados>
    {
        Task<List<Empleados>> PorCargo(Empleados? entidad);
    }
}
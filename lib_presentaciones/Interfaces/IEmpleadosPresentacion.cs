using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEmpleadosPresentacion : IGenericoPresentacion<Empleados>
    {
        Task<List<Empleados>> PorCargo(Empleados? entidad);
        Task<List<Empleados>> PorTelefono(Empleados? entidad);

    }
}
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IEmpleadosAplicacion : IGenericoAplicacion<Empleados>
    {
        List<Empleados> PorCargo(Empleados? entidad);

    }
}
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class EmpleadosAplicacion : GenericoAplicacion<Empleados>, IEmpleadosAplicacion
    {
        public EmpleadosAplicacion(IConexion iConexion) : base(iConexion)
        {
        }
        public List<Empleados> PorCargo(Empleados? entidad)
        {
            return this.IConexion!.Empleados!
            .Where(x => x.Cargo!.Contains(entidad!.Cargo!))
            .Take(50)
            .ToList();
        }
        public List<Empleados> PorTelefono(Empleados? entidad)
        {
            return this.IConexion!.Empleados!
                .Where(x => x.Telefono!.Contains(entidad!.Telefono!))
                .Take(50)
                .ToList();
        }


    }
}
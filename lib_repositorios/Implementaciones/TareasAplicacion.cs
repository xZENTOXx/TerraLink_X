using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class TareasAplicacion : GenericoAplicacion<Tareas>, ITareasAplicacion
    {
        public TareasAplicacion(IConexion iConexion) : base(iConexion) { }
        public List<Tareas> PorEmpleado(Tareas? entidad)
        {
            if (entidad == null )
                throw new Exception("lbFaltaInformacion");
            return this.IConexion!.Tareas!
                .Where(x => x.Empleado == entidad.Empleado)
                .Take(50)
                .ToList();
        }
    }
}

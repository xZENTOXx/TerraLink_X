using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ITareasAplicacion : IGenericoAplicacion<Tareas> {
    List<Tareas> PorEmpleado(Tareas? entidad);
    }
}

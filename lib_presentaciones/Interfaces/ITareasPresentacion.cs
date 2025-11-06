using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITareasPresentacion : IGenericoPresentacion<Tareas>
    {
        Task<List<Tareas>> PorEmpleado(Tareas? entidad);
    }
}

namespace lib_presentaciones.Interfaces
{
    public interface IGenericoPresentacion<T> where T : class
    {
        Task<List<T>> Listar();
        Task<T?> Guardar(T? entidad);
        Task<T?> Modificar(T? entidad);
        Task<T?> Borrar(T? entidad);
    }
}

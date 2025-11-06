using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface InventariosPresentacion : IGenericoPresentacion<Inventarios>
    {
        Task<List<Inventarios>> PorNombre(Inventarios? entidad);
    }
}
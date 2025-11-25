using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInventariosPresentacion : IGenericoPresentacion<Inventarios>
    {
        Task<List<Inventarios>> PorNombre(Inventarios? entidad);
        Task<List<Fincas>> ListarFincas();
    }
}
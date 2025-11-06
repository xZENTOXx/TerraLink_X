using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface PromocionesPresentacion : IGenericoPresentacion<Promociones>
    {
        Task<List<Promociones>> PorNombre(Promociones? entidad);
    }
}

using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPromocionesPresentacion : IGenericoPresentacion<Promociones>
    {
        Task<List<Promociones>> PorNombre(Promociones? entidad);
    }
}

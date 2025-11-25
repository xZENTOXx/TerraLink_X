using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IReseñasPresentacion : IGenericoPresentacion<Reseñas>
    {
        Task<List<Reseñas>> PorCalificacion(Reseñas? entidad);
        Task<List<Reseñas>> PorFecha(Reseñas? entidad);

    }
}
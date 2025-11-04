using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IReseñasAplicacion : IGenericoAplicacion<Reseñas>
    {
        List<Reseñas> PorCalificacion(Reseñas? entidad);

    }
}
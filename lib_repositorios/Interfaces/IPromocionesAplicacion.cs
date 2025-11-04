using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IPromocionesAplicacion : IGenericoAplicacion<Promociones>
    {
        List<Promociones> PorNombre(Promociones? entidad);

    }
}
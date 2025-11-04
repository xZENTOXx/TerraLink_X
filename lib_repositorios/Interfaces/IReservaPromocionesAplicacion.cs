using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IReservaPromocionesAplicacion : IGenericoAplicacion<ReservaPromociones> {
        List<ReservaPromociones> PorPromocion(ReservaPromociones? entidad);
    }
}

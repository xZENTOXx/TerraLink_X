using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IServiciosExtrasAplicacion : IGenericoAplicacion<ServiciosExtras> {
        List<ServiciosExtras> PorNombre(ServiciosExtras? entidad);
    }
}

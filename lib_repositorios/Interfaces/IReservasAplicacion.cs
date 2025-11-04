using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IReservasAplicacion : IGenericoAplicacion<Reservas> {
        List<Reservas> PorCliente(Reservas? entidad);
    }
}

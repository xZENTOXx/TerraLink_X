using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ReservasPresentacion : IGenericoPresentacion<Reservas>
    {
        Task<List<Reservas>> PorCliente(Reservas? entidad);
    }
}
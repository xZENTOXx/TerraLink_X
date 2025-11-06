using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPagosPresentacion : IGenericoPresentacion<Pagos>
    {
        Task<List<Pagos>> PorFechadePago(Pagos? entidad);
    }
}
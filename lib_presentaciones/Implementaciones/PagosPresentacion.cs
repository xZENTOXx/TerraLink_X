using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface PagosPresentacion : IGenericoPresentacion<Pagos>
    {
        Task<List<Pagos>> PorFechadePago(Pagos? entidad);
    }
}
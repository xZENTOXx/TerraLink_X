using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesPresentacion : IGenericoPresentacion<Clientes>
    {
        Task<List<Clientes>> PorCorreo(Clientes? entidad);
        Task<List<Clientes>> PorDocumento(Clientes? entidad);
    }
}

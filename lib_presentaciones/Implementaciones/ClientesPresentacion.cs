using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ClientesPresentacion : IGenericoPresentacion<Clientes>
    {
        Task<List<Clientes>> PorCorreo(Clientes? entidad);
    }
}

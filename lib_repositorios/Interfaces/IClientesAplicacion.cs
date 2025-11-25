using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClientesAplicacion : IGenericoAplicacion<Clientes>
    {
        List<Clientes> PorCorreo(Clientes? entidad);
        List<Clientes> PorDocumento(Clientes entidad);

    }
}
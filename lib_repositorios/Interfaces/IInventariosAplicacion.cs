using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IInventariosAplicacion : IGenericoAplicacion<Inventarios>
    {
        List<Inventarios> PorNombre(Inventarios? entidad);

    }
}
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IFincasAplicacion : IGenericoAplicacion<Fincas>
    {
        List<Fincas> PorUbicacion(Fincas? entidad);

    }
}

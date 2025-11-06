using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface FincasPresentacion : IGenericoPresentacion<Fincas>
    {
        Task<List<Fincas>> PorUbicacion(Fincas? entidad);
    }
}
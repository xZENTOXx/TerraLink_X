using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IMantenimientosAplicacion : IGenericoAplicacion<Mantenimientos>
    {
        List<Mantenimientos> PorResponsable(Mantenimientos? entidad);
        List<Mantenimientos> PorFecha(Mantenimientos? entidad);


    }
}
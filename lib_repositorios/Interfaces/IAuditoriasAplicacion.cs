using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IAuditoriasAplicacion : IGenericoAplicacion<Auditorias>
    {
        List<Auditorias> PorAccion(Auditorias? entidad);
        List<Auditorias> PorUsuario(int idUsuario);
        List<Auditorias> PorFecha(DateTime fecha);
    }
}

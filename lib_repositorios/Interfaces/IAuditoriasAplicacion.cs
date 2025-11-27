using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IAuditoriasAplicacion : IGenericoAplicacion<Auditorias>
    {
        List<Auditorias> PorFecha(DateTime fecha);
    }
}

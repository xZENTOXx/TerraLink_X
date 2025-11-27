using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class AuditoriasAplicacion : GenericoAplicacion<Auditorias>, IAuditoriasAplicacion
    {
        public AuditoriasAplicacion(IConexion conexion)
            : base(conexion) { }

        public List<Auditorias> PorFecha(DateTime fecha)
        {
            return this.IConexion!.Auditorias!
                .Where(x => x.Fecha.Date == fecha.Date)
                .OrderByDescending(x => x.Fecha)
                .Take(100)
                .ToList();
        }
    }
}

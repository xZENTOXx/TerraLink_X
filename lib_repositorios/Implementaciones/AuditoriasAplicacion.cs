using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class AuditoriasAplicacion : GenericoAplicacion<Auditorias>, IAuditoriasAplicacion
    {
        public AuditoriasAplicacion(IConexion conexion)
            : base(conexion)
        {
        }
        public List<Auditorias> PorAccion(Auditorias? entidad)
        {
            return this.IConexion!.Auditorias!
            .Where(x => x.Accion!.Contains(entidad!.Accion!))
            .Take(50)
            .ToList();
        }

    }
}
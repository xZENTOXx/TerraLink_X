using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        // Filtro adicional por usuario
        public List<Auditorias> PorUsuario(int idUsuario)
        {
            return this.IConexion!.Auditorias!
                .Include(x => x._Usuario)
                .Where(x => x.Usuario == idUsuario)
                .OrderByDescending(x => x.Fecha)
                .Take(100)
                .ToList();
        }
        // Filtro por fecha exacta
        public List<Auditorias> PorFecha(DateTime fecha)
        {
            return this.IConexion!.Auditorias!
                .Include(x => x._Usuario)
                .Where(x => x.Fecha.Date == fecha.Date)
                .OrderByDescending(x => x.Fecha)
                .Take(100)
                .ToList();
        }

    }
}
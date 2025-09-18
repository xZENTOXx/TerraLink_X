using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class AuditoriasAplicacion : GenericoAplicacion<Auditorias>, IAuditoriasAplicacion
    {
        public AuditoriasAplicacion(IConexion iConexion) : base(iConexion) { }
    }
}

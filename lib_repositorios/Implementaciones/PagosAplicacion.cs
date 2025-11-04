using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorios.Implementaciones
{
    public class PagosAplicacion : GenericoAplicacion<Pagos>, IPagosAplicacion
    {
        public PagosAplicacion(IConexion iConexion) : base(iConexion)
        {
        }
        public List<Pagos> PorFechadePago(Pagos? entidad)
        {
            return this.IConexion!.Pagos!
            .Where(x => x.FechadePago.Date == entidad!.FechadePago.Date)
            .Take(50)
            .ToList();
        }
    }
}
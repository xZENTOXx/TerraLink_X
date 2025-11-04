using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
namespace lib_repositorios.Implementaciones
{
    public class PromocionesAplicacion : GenericoAplicacion<Promociones>, IPromocionesAplicacion
    {
        public PromocionesAplicacion(IConexion iConexion) : base (iConexion)
        {
        }
        public List<Promociones> PorNombre(Promociones? entidad)
        {
            return this.IConexion!.Promociones!
            .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
            .Take(50)
            .ToList();
        }
    }
}
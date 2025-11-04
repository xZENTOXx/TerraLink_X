using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ReservaPromocionesAplicacion : GenericoAplicacion<ReservaPromociones>, IReservaPromocionesAplicacion
    {
        public ReservaPromocionesAplicacion(IConexion iConexion) : base(iConexion)
        {
        }
        public List<ReservaPromociones> PorPromocion(ReservaPromociones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            return this.IConexion!.ReservaPromociones!
                .Where(x => x.Promocion == entidad.Promocion)
                .Take(50)
                .ToList();
        }
    }
}

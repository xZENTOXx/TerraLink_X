using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ReservaServiciosAplicacion : GenericoAplicacion<ReservaServicios>, IReservaServiciosAplicacion
    {
        public ReservaServiciosAplicacion(IConexion iConexion) : base(iConexion) { }

        public List<ReservaServicios> PorServicio(ReservaServicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            return this.IConexion!.ReservaServicios!
                .Where(x => x.Servicio == entidad.Servicio)
                .Take(50)
                .ToList();
        }
    }
}

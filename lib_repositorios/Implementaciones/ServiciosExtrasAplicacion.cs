using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ServiciosExtrasAplicacion : GenericoAplicacion<ServiciosExtras>, IServiciosExtrasAplicacion
    {
        public ServiciosExtrasAplicacion(IConexion iConexion) : base(iConexion) { }

        public List<ServiciosExtras> PorNombre(ServiciosExtras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            return this.IConexion!.ServiciosExtras!
                .Where(x => x.Nombre.Contains(entidad.Nombre))
                .Take(50)
                .ToList();
        }
    }
}

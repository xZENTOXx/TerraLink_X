using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorios.Implementaciones
{
    public class MantenimientosAplicacion : GenericoAplicacion<Mantenimientos>, IMantenimientosAplicacion
    {

        public MantenimientosAplicacion(IConexion iConexion) : base(iConexion)
        {
        }
        public List<Mantenimientos> PorResponsable(Mantenimientos? entidad)
        {
            return this.IConexion!.Mantenimientos!
            .Where(x => x.Responsable!.Contains(entidad!.Responsable!))
            .Take(50)
            .ToList();
        }

        public List<Mantenimientos> PorFecha(Mantenimientos? entidad)
        {
            return this.IConexion!.Mantenimientos!
                .Where(x => x.Fecha.Date == entidad!.Fecha.Date)
                .Take(50)
                .ToList();
        }

    }
}
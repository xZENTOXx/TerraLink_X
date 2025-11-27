using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ReseñasAplicacion : GenericoAplicacion<Reseñas>, IReseñasAplicacion
    {
        public ReseñasAplicacion(IConexion iConexion) : base(iConexion)
        {
        }
        public List<Reseñas> PorCalificacion(Reseñas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            return this.IConexion!.Reseñas!
                .Where(x => x.Calificacion == entidad.Calificacion)
                .Include(x => x._Finca)
                .Include(x => x._Cliente)
                .Take(50)
                .ToList();
        }

        public List<Reseñas> PorFecha(Reseñas? entidad)
        {
            if (entidad?.Fecha == null)
                return new List<Reseñas>();

            var fecha = entidad.Fecha.Date;

            return this.IConexion!.Reseñas!
                .Where(x => x.Fecha.Date == fecha)
                .Include(x => x._Finca)
                .Include(x => x._Cliente)
                .Take(50)
                .ToList();
        }


    }
}

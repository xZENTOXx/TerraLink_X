using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
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
                .Take(50)
                .ToList();
        }
        public List<Reseñas> PorFecha(Reseñas? entidad)
        {
            return this.IConexion!.Reseñas!
                .Where(x => x.Fecha.Date == entidad!.Fecha.Date)
                .Take(50)
                .ToList();
        }

    }
}

using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class ReservasAplicacion : GenericoAplicacion<Reservas>, IReservasAplicacion
    {
        public ReservasAplicacion(IConexion iConexion) : base(iConexion) {}

        public List<Reservas> PorCliente(Reservas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            return this.IConexion!.Reservas!
                .Where(x => x.Cliente == entidad.Cliente)
                .Take(50)
                .ToList();
        }
    }
}

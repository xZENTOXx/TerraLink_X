using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorios.Implementaciones
{
    public class InventariosAplicacion : GenericoAplicacion<Inventarios>, IInventariosAplicacion
    {
        public InventariosAplicacion(IConexion iConexion) : base(iConexion)
        {
        }
        public List<Inventarios> PorNombre(Inventarios? entidad)
        {
            return this.IConexion!.Inventarios!
            .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
            .Take(50)
            .ToList();
        }
    }
}
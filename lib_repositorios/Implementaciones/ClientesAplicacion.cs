using lib_dominio.Entidades;
using lib_repositorios.Interfaces;


namespace lib_repositorios.Implementaciones
{
    public class ClientesAplicacion : GenericoAplicacion<Clientes>, IClientesAplicacion
    {
        public ClientesAplicacion(IConexion iConexion) : base(iConexion)
        {   
        }
      
        public List<Clientes> PorCorreo(Clientes? entidad)
        {
            return this.IConexion!.Clientes!
            .Where(x => x.Correo!.Contains(entidad!.Correo!))
            .Take(50)
            .ToList();
        }
        public List<Clientes> PorDocumento(Clientes entidad)
        {
            return this.IConexion!.Clientes!
                .Where(x => x.Documento.Contains(entidad.Documento))
                .Take(50)
                .ToList();
        }


    }
}
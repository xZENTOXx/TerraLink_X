using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ClientesPresentacion : GenericoPresentacion<Clientes>, IClientesPresentacion
    {
        public ClientesPresentacion(Comunicaciones comunicaciones) : base("Clientes", comunicaciones) { }
        public async Task<List<Clientes>> PorCorreo(Clientes? entidad)
        {
            var lista = new List<Clientes>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones!.ConstruirUrl(datos, "Clientes/PorCorreo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Clientes>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Clientes>> PorDocumento(Clientes? entidad)
        {
            var lista = new List<Clientes>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones!.ConstruirUrl(datos, "Clientes/PorDocumento");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Clientes>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));

            return lista;
        }

    }


}

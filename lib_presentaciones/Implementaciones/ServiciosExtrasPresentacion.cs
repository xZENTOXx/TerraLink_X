using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ServiciosExtrasPresentacion : GenericoPresentacion<ServiciosExtras>, IServiciosExtrasPresentacion
    {
        public ServiciosExtrasPresentacion(Comunicaciones comunicaciones) : base("ServiciosExtras", comunicaciones) { }
        public async Task<List<ServiciosExtras>> PorNombre(ServiciosExtras? entidad)
        {
            var lista = new List<ServiciosExtras>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones!.ConstruirUrl(datos, "ServiciosExtras/PorNombre");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ServiciosExtras>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
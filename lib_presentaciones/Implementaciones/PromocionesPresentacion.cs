using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class PromocionesPresentacion : GenericoPresentacion<Promociones>, IPromocionesPresentacion
    {
        public PromocionesPresentacion(Comunicaciones comunicaciones) : base("Promociones", comunicaciones) { }
        public async Task<List<Promociones>> PorNombre(Promociones? entidad)
        {
            var lista = new List<Promociones>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones?.ConstruirUrl(datos, "Promociones/PorTipo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Promociones>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}

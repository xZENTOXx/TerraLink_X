using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class InventariosPresentacion : GenericoPresentacion<Inventarios>, IInventariosPresentacion
    {
        public InventariosPresentacion(Comunicaciones comunicaciones) : base("Inventarios", comunicaciones) { }
        public async Task<List<Inventarios>> PorNombre(Inventarios? entidad)
        {
            var lista = new List<Inventarios>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones?.ConstruirUrl(datos, "Inventarios/PorTipo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Inventarios>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
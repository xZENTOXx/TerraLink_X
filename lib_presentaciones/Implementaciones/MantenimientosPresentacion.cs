using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class MantenimientosPresentacion : GenericoPresentacion<Mantenimientos>, IMantenimientosPresentacion
    {
        public MantenimientosPresentacion(Comunicaciones comunicaciones) : base("Mantenimientos", comunicaciones) { }
        public async Task<List<Mantenimientos>> PorResponsable(Mantenimientos? entidad)
        {
            var lista = new List<Mantenimientos>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones?.ConstruirUrl(datos, "Mantenimientos/PorTipo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Mantenimientos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
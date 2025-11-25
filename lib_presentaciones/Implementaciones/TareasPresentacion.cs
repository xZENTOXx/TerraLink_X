using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class TareasPresentacion : GenericoPresentacion<Tareas>, ITareasPresentacion
    {
        public TareasPresentacion(Comunicaciones comunicaciones) : base("Tareas", comunicaciones) { }
        public async Task<List<Tareas>> PorEmpleado(Tareas? entidad)
        {
            var lista = new List<Tareas>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones!.ConstruirUrl(datos, "Tareas/PorEmpleado");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Tareas>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
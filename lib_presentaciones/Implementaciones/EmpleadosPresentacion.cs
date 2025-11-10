using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class EmpleadosPresentacion : GenericoPresentacion<Empleados>, IEmpleadosPresentacion
    {
        public EmpleadosPresentacion(Comunicaciones comunicaciones) : base("Empleados", comunicaciones) { }
        public async Task<List<Empleados>> PorCargo(Empleados? entidad)
        {
            var lista = new List<Empleados>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones?.ConstruirUrl(datos, "Empleados/PorTipo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Empleados>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
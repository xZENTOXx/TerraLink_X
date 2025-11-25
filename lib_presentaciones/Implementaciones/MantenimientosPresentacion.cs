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
            datos = comunicaciones!.ConstruirUrl(datos, "Mantenimientos/PorResponsable");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Mantenimientos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
        public async Task<List<Mantenimientos>> PorFecha(Mantenimientos? entidad)
        {
            var lista = new List<Mantenimientos>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            datos = comunicaciones!.ConstruirUrl(datos, "Mantenimientos/PorFecha");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"].ToString()!);

            lista = JsonConversor.ConvertirAObjeto<List<Mantenimientos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));

            return lista;
        }

        public async Task<List<Fincas>> ListarFincas()
        {
            var lista = new List<Fincas>();

            var datos = new Dictionary<string, object>();
            datos = comunicaciones!.ConstruirUrl(datos, "Fincas/Listar");

            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }

            lista = JsonConversor.ConvertirAObjeto<List<Fincas>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));

            return lista;
        }


    }
}
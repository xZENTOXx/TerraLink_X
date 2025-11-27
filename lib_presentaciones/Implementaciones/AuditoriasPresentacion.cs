using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using lib_dominio.Nucleo;

namespace lib_presentaciones.Implementaciones
{
    public class AuditoriasPresentacion : GenericoPresentacion<Auditorias>, IAuditoriasPresentacion
    {
        public AuditoriasPresentacion(Comunicaciones comunicaciones)
            : base("Auditorias", comunicaciones)
        { }

        public async Task<List<Auditorias>> PorFecha(DateTime fecha)
        {
            var datos = new Dictionary<string, object>();
            datos["Fecha"] = fecha;

            datos = comunicaciones!.ConstruirUrl(datos, "Auditorias/PorFecha");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"]!.ToString());

            return JsonConversor.ConvertirAObjeto<List<Auditorias>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
        }
    }
}

using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ReseñasPresentacion : GenericoPresentacion<Reseñas>, IReseñasPresentacion  
    {
        public ReseñasPresentacion(Comunicaciones comunicaciones) : base("Reseñas", comunicaciones) { }
        public async Task<List<Reseñas>> PorCalificacion(Reseñas? entidad)
        {
            var lista = new List<Reseñas>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones!.ConstruirUrl(datos, "Reseñas/PorCalificacion");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Reseñas>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
        public async Task<List<Reseñas>> PorFecha(Reseñas? entidad)
        {
            var lista = new List<Reseñas>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            datos = comunicaciones!.ConstruirUrl(datos, "Reseñas/PorFecha");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"].ToString()!);

            lista = JsonConversor.ConvertirAObjeto<List<Reseñas>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));

            return lista;
        }

    }
}
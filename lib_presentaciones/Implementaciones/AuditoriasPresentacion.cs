using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class AuditoriasPresentacion : GenericoPresentacion<Auditorias>, IAuditoriasPresentacion
    {
        public AuditoriasPresentacion(Comunicaciones comunicaciones) : base( "Auditorias",comunicaciones) { }
        public async Task<List<Auditorias>> PorAccion(Auditorias? entidad)
        {
            var lista = new List<Auditorias>();

            var datos = new Dictionary<string, object>();
                datos["Entidad"] = entidad!;
                datos = comunicaciones?.ConstruirUrl(datos, "Auditorias/PorTipo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Auditorias>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
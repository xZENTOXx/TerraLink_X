using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ReservaServiciosPresentacion : GenericoPresentacion<ReservaServicios>, IReservaServiciosPresentacion
    {
        public ReservaServiciosPresentacion(Comunicaciones comunicaciones) : base("ReservaServicios", comunicaciones) { }
        public async Task<List<ReservaServicios>> PorServicio(ReservaServicios? entidad)
        {
            var lista = new List<ReservaServicios>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones?.ConstruirUrl(datos, "ReservaServicios/PorTipo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ReservaServicios>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
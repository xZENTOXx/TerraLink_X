using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ReservaPromocionesPresentacion : GenericoPresentacion<ReservaPromociones>, IReservaPromocionesPresentacion
    {
        public ReservaPromocionesPresentacion(Comunicaciones comunicaciones) : base("ReservaPromociones", comunicaciones) { }
        public async Task<List<ReservaPromociones>> PorPromocion(ReservaPromociones? entidad)
        {
            var lista = new List<ReservaPromociones>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones!.ConstruirUrl(datos, "ReservaPromociones/PorPromocion");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ReservaPromociones>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
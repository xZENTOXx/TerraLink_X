using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class PagosPresentacion : GenericoPresentacion<Pagos>, IPagosPresentacion
    {
        public PagosPresentacion(Comunicaciones comunicaciones) : base("Pagos", comunicaciones) { }
        public async Task<List<Pagos>> PorFechadePago(Pagos? entidad)
        {
            var lista = new List<Pagos>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones?.ConstruirUrl(datos, "Pagos/PorTipo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Pagos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
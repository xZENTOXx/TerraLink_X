using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ReservasPresentacion : GenericoPresentacion<Reservas>, IReservasPresentacion
    {
        public ReservasPresentacion(Comunicaciones comunicaciones) : base("Reservas", comunicaciones) { }
        public async Task<List<Reservas>> PorCliente(Reservas? entidad)
        {
            var lista = new List<Reservas>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones?.ConstruirUrl(datos, "Reservas/PorTipo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Reservas>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
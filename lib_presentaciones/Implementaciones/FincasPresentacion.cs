using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class FincasPresentacion : GenericoPresentacion<Fincas>, IFincasPresentacion
    {
        public FincasPresentacion(Comunicaciones comunicaciones) : base("Fincas", comunicaciones)  { }
        public async Task<List<Fincas>> PorUbicacion(Fincas? entidad)
        {
            var lista = new List<Fincas>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones!.ConstruirUrl(datos, "Fincas/PorUbicacion");
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
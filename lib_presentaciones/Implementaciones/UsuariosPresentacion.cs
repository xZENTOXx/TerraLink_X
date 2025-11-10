using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class UsuariosPresentacion : GenericoPresentacion<Usuarios>, IUsuariosPresentacion
    {
        public UsuariosPresentacion(Comunicaciones comunicaciones) : base("Usuarios", comunicaciones) { }
        public async Task<List<Usuarios>> PorNombre_Usuario(Usuarios? entidad)
        {
            var lista = new List<Usuarios>();

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos = comunicaciones?.ConstruirUrl(datos, "Usuarios/PorTipo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Usuarios>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
    }
}
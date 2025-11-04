using lib_repositorios.Interfaces;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using asp_servicios.Nucleo;
namespace asp_servicios.Controllers
{
    public class UsuariosController
                 : GenericoController<Usuarios, IUsuariosAplicacion>
    {
        public UsuariosController(IUsuariosAplicacion? iAplicacion,TokenController tokenController)
               : base (iAplicacion, tokenController){}
        [HttpPost]
        public string PorNombre_Usuario()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Usuarios>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                respuesta["Entidades"] = this.iAplicacion!.PorNombre_Usuario(entidad);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}


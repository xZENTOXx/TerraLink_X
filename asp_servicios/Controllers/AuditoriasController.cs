using asp_servicios.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    public class AuditoriasController
            : GenericoController<Auditorias, IAuditoriasAplicacion>
    {
        public AuditoriasController(
            IAuditoriasAplicacion aplicacion,
            TokenController tokenController)
            : base(aplicacion, tokenController)
        {
        }

        [HttpPost]
        public string PorFecha()
        {
            var respuesta = new Dictionary<string, object>();

            try
            {
                var datos = ObtenerDatos();
                var fecha = Convert.ToDateTime(datos["Fecha"]!.ToString());

                this.iAplicacion!.Configurar(
                    Configuracion.ObtenerValor("StringConexion"));

                respuesta["Entidades"] = this.iAplicacion!.PorFecha(fecha);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message;
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}

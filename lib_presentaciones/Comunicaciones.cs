using lib_dominio.Nucleo;

namespace lib_presentaciones
{
    public class Comunicaciones
    {
        private string? URL = string.Empty;
        private string? llave = null;

        public Comunicaciones(string url = "http://localhost:5175/")
        {
            URL = url;
        }

        public Dictionary<string, object> ConstruirUrl(Dictionary<string, object> data, string Metodo)
        {
            data["Url"] = URL + Metodo;
            data["UrlLlave"] = URL + "Token/Llave";
            return data;
        }

        public async Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                // Obtener llave primero
                respuesta = await Llave(datos);
                if (respuesta == null || respuesta.ContainsKey("Error"))
                    return respuesta;

                respuesta.Clear();

                if (string.IsNullOrEmpty(llave))
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                // Preparar datos para envío
                var url = datos["Url"].ToString();
                datos.Remove("Url");
                datos.Remove("UrlLlave");
                datos["Llave"] = llave;

                var stringData = JsonConversor.ConvertirAString(datos);

                var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(4);

                var message = await httpClient.PostAsync(url, new StringContent(stringData));

                if (!message.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                var resp = await message.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                // Convertir JSON limpio
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }

        private async Task<Dictionary<string, object>> Llave(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();

            try
            {
                var url = datos["UrlLlave"].ToString();
                var temp = new Dictionary<string, object>()
                {
                    ["Entidad"] = new Dictionary<string, object>()
                    {
                        { "NombreUsuario", "admin" },
                        { "Clave", "admin123" }
                    }
                };

                var stringData = JsonConversor.ConvertirAString(temp);

                var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(1);

                var mensaje = await httpClient.PostAsync(url, new StringContent(stringData));

                if (!mensaje.IsSuccessStatusCode)
                {
                    respuesta["Error"] = "lbErrorComunicacion";
                    return respuesta;
                }

                var resp = await mensaje.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(resp))
                {
                    respuesta["Error"] = "lbErrorComunicacion";
                    return respuesta;
                }

                respuesta = JsonConversor.ConvertirAObjeto(resp);

                llave = respuesta["Llave"]?.ToString();
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }
    }
}

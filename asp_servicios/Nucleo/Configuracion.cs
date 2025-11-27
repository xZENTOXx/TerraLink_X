using lib_dominio.Nucleo;

namespace asp_servicios.Nucleo
{
    // Esta clase es la “encargada” de leer el secrets.json y
    // darnos valores por clave (ej: "StringConexion").
    // La idea es: leer el archivo una sola vez y guardar los datos en memoria.
    public class Configuracion
    {
        // Aquí guardamos en memoria el contenido del JSON como diccionario.
        // Es static para que se comparta en toda la app y no leer el archivo cada rato.
        private static Dictionary<string, string>? datos = null;

        // Devuelve el valor de una clave del JSON (por ejemplo: "StringConexion").
        public static string ObtenerValor(string clave)
        {
            string respuesta = "";

            // Si todavía no hemos cargado el JSON, lo cargamos una vez.
            if (datos == null)
                Cargar();

            // Con el "!" le decimos al compilador que confiamos en que 'datos' ya no es null.
            // OJO: si la clave no existe, tirará excepción. (Puedes mejorar con TryGetValue).
            respuesta = datos![clave].ToString();

            return respuesta;
        }

        // Lee el archivo secrets.json desde la ruta que definimos en DatosGenerales.ruta_json
        // y lo convierte a diccionario para usarlo en ObtenerValor.
        public static void Cargar()
        {
            // Si el archivo no existe, simplemente salimos (no hacemos nada).
            // Luego, si llamas ObtenerValor y nunca se cargó, fallará.
            // (Se puede mejorar mostrando un mensaje o lanzando una excepción amigable).
            if (!File.Exists(DatosGenerales.ruta_json))
            {
                Console.WriteLine("ARCHIVO NO ENCONTRADO EN: " + DatosGenerales.ruta_json);
                return;
            }

            Console.WriteLine("ARCHIVO SÍ ENCONTRADO EN: " + DatosGenerales.ruta_json);


            // Abrimos y leemos todo el contenido del JSON.
            StreamReader jsonStream = File.OpenText(DatosGenerales.ruta_json);
            var json = jsonStream.ReadToEnd();

            // Convertimos el JSON a Dictionary<string, string>.
            // JsonConversor es una ayudita que ya tienes en lib_dominio.
            datos = JsonConversor.ConvertirAObjeto<Dictionary<string, string>>(json)!;
        }
    }
}

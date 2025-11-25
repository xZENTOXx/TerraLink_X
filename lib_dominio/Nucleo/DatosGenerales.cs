namespace lib_dominio.Nucleo
{
    public class DatosGenerales
    {
        // Ruta donde se encuentra el archivo JSON con las credenciales
        public static string ruta_json = @"C:\Users\juand\OneDrive\Documentos\2-ACADEMICO\ITM\2025-2\3-Programación de Software\TerraLink_X\secrets.json";
        public static bool usa_azure = false;
        public static string clave = "EVBgi345936456ghhVBJGtgnifytsidi3456678jhgUTytutyiiyi";
        public static string usuario_datos = EncriptarConversor.Encriptar("Test.Trghhjsgdj");
    }
}
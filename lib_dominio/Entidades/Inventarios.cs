
namespace lib_dominio.Entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int Finca { get; set; }
        public Fincas? _Finca { get; set; }
        public required string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; } = "Bueno";
    }
}


namespace lib_dominio.Entidades
{
    public class Mantenimientos
    {
        public int Id { get; set; }
        public int Finca { get; set; }
        public required string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Today;

        public string? Responsable { get; set; }

    }
}

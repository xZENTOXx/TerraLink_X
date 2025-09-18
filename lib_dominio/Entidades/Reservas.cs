
namespace lib_dominio.Entidades
{
    public class Reservas
    {
        public int Id { get; set; }
        public required DateTime FechaInicio { get; set;}
        public required DateTime FechaFin { get; set;}
        public required string Estado { get; set; }
        public decimal Total { get; set; }
        public int Finca { get; set; }
        public int Cliente { get; set; }
    }
}

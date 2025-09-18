
namespace lib_dominio.Entidades
{
    public class Promociones
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public decimal Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; } = true;


    }
}

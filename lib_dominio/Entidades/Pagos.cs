
namespace lib_dominio.Entidades
{
    public class Pagos
    {
        public int Id { get; set; }
        public int Reserva { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechadePago { get; set; } = DateTime.Now;

        public required string Metodo { get; set; }
    }
}

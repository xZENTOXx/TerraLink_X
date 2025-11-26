
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Pagos : IEntidad
    {
        public int Id { get; set; }
        public int Reserva { get; set; }
        public Reservas? _Reserva { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechadePago { get; set; } = DateTime.Now;
        [Required] public string Metodo { get; set; } = String.Empty;
    }
}

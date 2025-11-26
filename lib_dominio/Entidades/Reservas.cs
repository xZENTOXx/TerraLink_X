
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Reservas : IEntidad
    {
        public int Id { get; set; }
        [Required] public DateTime FechaInicio { get; set;}
        [Required] public  DateTime FechaFin { get; set;}
        [Required] public string Estado { get; set; } = String.Empty;
        public decimal Total { get; set; }
        public int Finca { get; set; }
        public int Cliente { get; set; }
        public Fincas? _Finca { get; set; }
        public Clientes? _Cliente { get; set; }
    }
}

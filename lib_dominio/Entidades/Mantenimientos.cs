using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Mantenimientos : IEntidad
    {
        public int Id { get; set; }
        public int Finca { get; set; }
        public Fincas? _Finca { get; set; }
        [Required] public string Descripcion { get; set; } = String.Empty;
        public decimal Costo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Today;
        public string? Responsable { get; set; }

    }
}
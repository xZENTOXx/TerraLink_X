
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Inventarios : IEntidad
    {
        public int Id { get; set; }
        public int Finca { get; set; }
        public Fincas? _Finca { get; set; }
        [Required] public string Nombre { get; set; } = String.Empty;
        public int Cantidad { get; set; }
        public string Estado { get; set; } = "Bueno";
    }
}

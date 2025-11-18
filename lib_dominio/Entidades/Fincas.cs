using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Fincas : IEntidad
    {
        public int Id { get; set; }
        [Required] public string Nombre { get; set; } = string.Empty;
        [Required] public string Ubicacion { get; set; } = string.Empty;
        public int Capacidad { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioBase { get; set; }
        public bool Estado { get; set; } = true;
    }

}

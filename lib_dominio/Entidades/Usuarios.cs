
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Usuarios : IEntidad
    {
        public int Id { get; set; }
        [Required] public string NombreUsuario { get; set; } = string.Empty;
        [Required] public string Clave { get; set; } = string.Empty;
        [Required] public string Rol { get; set; } = string.Empty;

    }
}

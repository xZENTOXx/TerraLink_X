
namespace lib_dominio.Entidades
{
    public class Usuarios : IEntidad
    {
        public int Id { get; set; }
        public required string NombreUsuario { get; set; }
        public required string Clave { get; set; }
        public required string Rol { get; set; }

    }
}

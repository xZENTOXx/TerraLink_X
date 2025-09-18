
namespace lib_dominio.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Cargo { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

    }
}

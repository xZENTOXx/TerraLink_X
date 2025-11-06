
namespace lib_dominio.Entidades
{
    public class Clientes : IEntidad
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Correo { get; set; }
        public string? Telefono { get; set; }
        public required string Documento { get; set; }
    }
}

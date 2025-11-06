
namespace lib_dominio.Entidades
{
    public class ServiciosExtras : IEntidad
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; } = true;
    }

}

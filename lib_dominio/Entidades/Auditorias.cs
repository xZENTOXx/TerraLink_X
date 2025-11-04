
namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public Usuarios? _Usuario { get; set; }
        public required string Accion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string? TablaAfectada { get; set; }
        public int? IdRegistroAfectado { get; set; }
    }
}


namespace lib_dominio.Entidades
{
    public class Auditorias : IEntidad
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Accion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string? TablaAfectada { get; set; }
        public int? IdRegistroAfectado { get; set; }
    }
}

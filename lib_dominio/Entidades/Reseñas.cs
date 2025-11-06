
namespace lib_dominio.Entidades
{
    public class Reseñas : IEntidad
    {
        public int Id { get; set; }
        public int Finca { get; set; }
        public int Cliente { get; set; }
        public Fincas? _Finca { get; set; }
        public Clientes? _Cliente { get; set; }
        public int Calificacion { get; set; }
        public string? Comentario { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

    }
}

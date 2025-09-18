
namespace lib_dominio.Entidades
{
    public class Reseñas
    {
        public int Id { get; set; }
        public int Finca { get; set; }
        public int Cliente { get; set; }
        public int Calificacion { get; set; }
        public string? Comentario { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

    }
}

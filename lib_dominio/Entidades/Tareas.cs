
namespace lib_dominio.Entidades
{
    public class Tareas
    {
        public int Id { get; set; }
        public int Empleado { get; set; }
        public int Finca { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaAsignacion { get; set; } = DateTime.Today;

        public string? Estado { get; set; } = "Pendiente";

    }
}



namespace lib_dominio.Entidades
{
    public class Tareas : IEntidad
    {
        public int Id { get; set; }
        public int Empleado { get; set; }
        public int Finca { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaAsignacion { get; set; } = DateTime.Today;
        public string? Estado { get; set; } = "Pendiente";
        public Empleados? _Empleado { get; set; }
        public Fincas? _Finca { get; set; }

    }
}

